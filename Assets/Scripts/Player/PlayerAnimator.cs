using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour {

    [SerializeField] Animator[] _animators;

    private Rigidbody2D _rigiRigidbody;
    

    // Start is called before the first frame update
    void Start() {
        _rigiRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        for ( int i = 0; i < _animators.Length; i++ ) {
            _animators[i].SetFloat("HorizontalSpeed", _rigiRigidbody.velocity.x);
            _animators[i].SetFloat("VerticalSpeed", _rigiRigidbody.velocity.y);
        }        
    }
}
