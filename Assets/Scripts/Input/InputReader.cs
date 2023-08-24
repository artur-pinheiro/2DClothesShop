using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/Input/InputReader")]
public class InputReader : ScriptableObject, InputActions.IGameplayActions {

    public event UnityAction InteractEvent = delegate { };
    public event UnityAction<Vector2> MoveEvent = delegate { };

    private InputActions _gameInput;

    private void OnEnable() {
        if ( _gameInput == null ) {
            _gameInput = new InputActions();
            _gameInput.Gameplay.SetCallbacks(this);
        }
    }

    private void OnDisable() {
        DisableInput();
    }

    public void EnableInput() {
        _gameInput.Gameplay.Enable();
    }

    public void DisableInput() {
        _gameInput.Gameplay.Disable();
    }

    public void OnInteract(InputAction.CallbackContext context) {
        if ( context.phase == InputActionPhase.Performed )
            InteractEvent.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context) {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }
}
