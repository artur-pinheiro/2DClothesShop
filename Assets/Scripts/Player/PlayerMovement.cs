using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _speed;
    [SerializeField] private InputReader _inputReader;
    
    private Rigidbody2D _rigidBody;

    #region UNITY_FUNCTIONS
    private void OnEnable() {
        _inputReader.MoveEvent += Move;
        _inputReader.EnableInput();
    }
    private void OnDisable() {
        _inputReader.MoveEvent -= Move;
    }

    void Start() {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region PRIVATE_METHODS
    private void Move(Vector2 axis) {
        _rigidBody.velocity = axis * _speed;
    }
    #endregion
}
