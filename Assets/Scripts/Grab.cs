using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Grab : MonoBehaviour
{
    [SerializeField] private Sprite HandOpen;
    [SerializeField] private Sprite HandClosed;

    private bool _grabbingLastFrame;
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
        
        if (grabbingThisFrame != _grabbingLastFrame)
            HandleGrabChange(grabbingThisFrame);
        
        _grabbingLastFrame = grabbingThisFrame;
    }
    void HandleGrabChange(bool isGrabbing)
    {
        if (isGrabbing)
        {
            _spriteRenderer.sprite = HandClosed;

            //attach first hit food to self
            var hitColliders = Physics2D.OverlapPointAll(_rigidBody2D.position, LayerMask.NameToLayer("Grabbable"));
            if (hitColliders.Length > 0)
            {
                var _foodBeingGrabbed = hitColliders[0].GetComponent<FixedJoint2D>();
                if (_foodBeingGrabbed != null)
                    _foodBeingGrabbed.connectedBody = _rigidBody2D;
                else 
                    Debug.LogWarning("This object is in the grabbable layer but cannot be grabbed because it does not have a fixedJoint2D!");
            }
        }
        else
        {
            _spriteRenderer.sprite = HandOpen;
            if (_foodBeingGrabbed != null)
                _foodBeingGrabbed.connectedBody = null;
        }
    }

    void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();
    
}
