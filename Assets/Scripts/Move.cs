using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField]
    private float Sensitvity;
    
    private ControlsMain _input;
    private Rigidbody2D _rigidBody2D;
    private Camera _main;

    void Awake()
    {
        _input = new ControlsMain();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _main = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

    void Update()
    {
        //var toMove = Sensitvity * _input.Hand.Move.ReadValue<Vector2>();
        //_rigidBody2D.position += toMove;
        
        var newPos = _main.ScreenToWorldPoint(Input.mousePosition).ToVector2XY();
        _rigidBody2D.position = newPos;
    }
}
