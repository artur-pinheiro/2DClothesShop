using UnityEngine;
using UnityEngine.Events;

public class Seller : MonoBehaviour, IInteractable {

    [SerializeField] InputReader _inputReader;

    public UnityEvent OnInteract;
    public UnityEvent OnCancel;

    public void Interact() {
        _inputReader.DisableInput();
        OnInteract?.Invoke();
    }

    public void CancelAndClose() {
        _inputReader.EnableInput();
        OnCancel?.Invoke();
    }

}
