using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/Input/InputReader")]
public class InputReader : ScriptableObject, InputActions.IGameplayActions, InputActions.IGameplayUIActions {

    public event UnityAction InteractEvent = delegate { };
    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction CancelEvent = delegate { };
    public event UnityAction InventoryEvent = delegate { };

    private InputActions _gameInput;

    private void OnEnable() {
        if ( _gameInput == null ) {
            _gameInput = new InputActions();
            _gameInput.Gameplay.SetCallbacks(this);
            _gameInput.GameplayUI.SetCallbacks(this);
        }
    }

    private void OnDisable() {
        DisableInput();
    }

    public void EnableInput() {
        _gameInput.Gameplay.Enable();
        _gameInput.GameplayUI.Disable();
    }

    public void DisableInput() {
        _gameInput.Gameplay.Disable();
        _gameInput.GameplayUI.Enable();
    }

    public void OnInteract(InputAction.CallbackContext context) {
        if ( context.phase == InputActionPhase.Performed )
            InteractEvent.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context) {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnCancel(InputAction.CallbackContext context) {
        if ( context.phase == InputActionPhase.Performed )
            CancelEvent.Invoke();
    }

    public void OnInventory(InputAction.CallbackContext context) {
        if ( context.phase == InputActionPhase.Performed )
            InventoryEvent.Invoke();
    }
}
