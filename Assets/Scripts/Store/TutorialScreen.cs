using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour {

    [SerializeField] private Button _closeButton;
    [SerializeField] private InputReader _inputReader;

    // Start is called before the first frame update
    void Start() {
        _inputReader.DisableInput();
        _closeButton.Select();
    }
}
