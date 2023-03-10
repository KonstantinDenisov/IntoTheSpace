using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    #region Variables

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _theSoundOfAGunshotClip;
    public bool SoundOff;

    #endregion


    #region Public Methods

    public void PlaySound(AudioClip audioClip)
    {
        if (audioClip == null || SoundOff)
            return;

        _audioSource.PlayOneShot(audioClip);
    }

    public void AddTheSoundOfAGunshotClip()
    {
        PlaySound(_theSoundOfAGunshotClip);
    }

    #endregion
}
