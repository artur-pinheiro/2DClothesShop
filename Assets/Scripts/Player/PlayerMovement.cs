using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _speed;
    [SerializeField] private float _inputClampValue;
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
        print(axis);
        _rigidBody.velocity = new Vector2(ClampValue(axis.x, _inputClampValue), ClampValue(axis.y, _inputClampValue)) * _speed;
    }

    float ClampValue(float value, float min) {
        if ( MathF.Sign(value) == -1 ) {
            if ( value > -min ) {
                return 0f;
            }
        } else {
            if ( value < min ) {
                return 0f;
            }
        }
        return value;
    }

    #endregion
}
