using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Grab : MonoBehaviour
{
    [SerializeField] private Sprite HandOpen;
    [SerializeField] private Sprite HandClosed;
    [SerializeField] private float ColliderRadius = 2f;
    [SerializeField] private Vector2 ColliderOffset;
    [SerializeField] private float ForceReleaseMultiplier = 1f;
    [Range(0f,1f)]
    [SerializeField] private float DeltaPosLerpAmount = 0.5f;
    private Vector2 ColliderPosition
    {
        get
        {
            if (_rigidBody2D != null)
                return _rigidBody2D.position + ColliderOffset;
            else
                return GetComponent<Rigidbody2D>().position + ColliderOffset;
        }
    }

    private bool _grabbingLastFrame;
    private Vector2 _positionLastFrame;
    private Vector2 _deltaPos;
    
    private ControlsMain _input;
    private Rigidbody2D _rigidBody2D;
    private SpriteRenderer _spriteRenderer;
    private Joint2D _foodBeingGrabbed;
    

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _input = new ControlsMain();
    }

    void Update()
    {
        bool grabbingThisFrame = (_input.Hand.Grab.ReadValue<float>() > 0.5f);

        var lastFramesDeltaPos = transform.position.ToVector2XY() - _positionLastFrame;
        _deltaPos = Vector2.Lerp(_deltaPos, lastFramesDeltaPos, DeltaPosLerpAmount);
        
        if (grabbingThisFrame != _grabbingLastFrame)
            HandleGrabChange(grabbingThisFrame);
        
        _grabbingLastFrame = grabbingThisFrame;
        _positionLastFrame = transform.position.ToVector2XY();
    }
    void HandleGrabChange(bool isGrabbing)
    {
        if (isGrabbing)
        {
            _spriteRenderer.sprite = HandClosed;

            //attach first hit food to self
            var hitColliders = Physics2D.OverlapCircleAll(ColliderPosition, ColliderRadius, 0b_1111_0000_0000);
            Debug.Log(hitColliders.Length);
            if (hitColliders.Length > 0)
            {
                _foodBeingGrabbed = hitColliders[0].GetComponent<FixedJoint2D>();
                if (_foodBeingGrabbed != null)
                {
                    _foodBeingGrabbed.enabled = true;
                    _foodBeingGrabbed.connectedBody = _rigidBody2D;
                    _foodBeingGrabbed.attachedRigidbody.velocity = Vector2.zero;
                }
                else 
                    Debug.LogWarning("This object is in the grabbable layer but cannot be grabbed because it does not have a fixedJoint2D!");
            }
        }
        else
        {
            _spriteRenderer.sprite = HandOpen;
            if (_foodBeingGrabbed != null)
            {
                _foodBeingGrabbed.enabled = false;
                _foodBeingGrabbed.connectedBody = null;
                _foodBeingGrabbed.attachedRigidbody.velocity = _deltaPos * ForceReleaseMultiplier;
            }
 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ColliderPosition, ColliderRadius);
        Gizmos.DrawLine(transform.position, transform.position.ToVector2XY() + _deltaPos*ForceReleaseMultiplier);
    }

    void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
    
}
