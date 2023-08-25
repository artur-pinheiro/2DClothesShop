using System;
using UnityEngine;
using Random = UnityEngine.Random;

public enum AudioType {
    CLICK,
    CLOTH,
    COIN
}

public class AudioController : MonoBehaviour {

    [SerializeField] AudioSource _Source;
    [SerializeField] AudioClip[] _clickSounds;
    [SerializeField] AudioClip[] _clothSounds;
    [SerializeField] AudioClip[] _coinSounds;
    [SerializeField] PlayAudioChannelSO _playAudioChannel;

    private void OnEnable() {
        _playAudioChannel.OnPlaySound += PlaySound;
    }

    private void OnDisable() {
        _playAudioChannel.OnPlaySound -= PlaySound;
    }

    public void PlaySound(string audioType) {
        AudioType valorEnum = (AudioType)Enum.Parse(typeof(AudioType), audioType);

        switch ( valorEnum ) {
            case AudioType.CLICK:
                _Source.PlayOneShot(_clickSounds[Random.Range(0, _clickSounds.Length)]);
                break;
            case AudioType.CLOTH:
                _Source.PlayOneShot(_clothSounds[Random.Range(0, _clothSounds.Length)]);
                break;
            case AudioType.COIN:
                _Source.PlayOneShot(_coinSounds[Random.Range(0, _coinSounds.Length)]);
                break;
            default:
                break;
        }

    }

}
