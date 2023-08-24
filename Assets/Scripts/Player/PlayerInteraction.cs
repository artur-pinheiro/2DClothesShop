using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private string[] _interactionTags;

    private bool _isInteracting = false;
    private IInteractable _currentInteraction;
    private string _currentInteractionTag = "";

    #region UNITY_FUNCTIONS
    private void OnEnable() {
        _inputReader.InteractEvent += Interact;
    }

    private void OnDisable() {
        _inputReader.InteractEvent -= Interact;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        foreach ( string tag in _interactionTags ) {
            if (collision.CompareTag(tag)) {
                if (collision.transform.parent.TryGetComponent(out IInteractable interactable)) {
                    _isInteracting = true;
                    _currentInteraction = interactable;
                    _currentInteractionTag = tag;
                    break;
                }                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if ( collision.CompareTag(_currentInteractionTag) ) {
                _isInteracting = false;
        }       
    }

    #endregion

    #region PRIVATE_METHODS
    private void Interact() {
        if (_isInteracting) {
            _currentInteraction.Interact();
        }
    }
    #endregion
}
