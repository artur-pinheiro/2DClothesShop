using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayAudioChannel", menuName = "ScriptableObjects/Channels/Play Audio")]
public class PlayAudioChannelSO : ScriptableObject {
    public UnityAction<string> OnPlaySound;

    public void RaisePlaySound(string audio) {
        OnPlaySound?.Invoke(audio);
    }
}
