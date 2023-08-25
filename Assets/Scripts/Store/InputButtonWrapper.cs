using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]

public class InputButtonWrapper : MonoBehaviour {

    [SerializeField] string _actionCallback;
    [SerializeField] InputReader _inputReader;

    private Button _button;

    private void OnEnable() {
        _button = GetComponent<Button>();
        switch ( _actionCallback ) {
            case "CancelEvent":
                _inputReader.CancelEvent += ClickButton;
                break;
            default: //would put the other cases in the future when they were needed
                break;
        }
    }

    private void OnDisable() {
        switch ( _actionCallback ) {
            case "CancelEvent":
                _inputReader.CancelEvent -= ClickButton;
                break;
            default:
                break;
        }
    }

    private void ClickButton() {
        _button.onClick.Invoke();
    }
}
