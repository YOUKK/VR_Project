using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyAudio : MonoBehaviour
{
    public AudioClip toySound1; // 장난감 소리
    public AudioClip toySound2; // 비프음 소리
    private AudioSource audioSource;

    public int CurrentSoundIndex { get; private set; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public int PlayRandomToySound()
    {
        if (toySound1 == null || toySound2 == null)
        {
            Debug.LogError("Audio clips are not assigned to ToyAudio script.");
            return -1; // 소리 선택 실패
        }

        CurrentSoundIndex = Random.Range(0, 2);
        AudioClip selectedClip = CurrentSoundIndex == 0 ? toySound1 : toySound2;
        audioSource.clip = selectedClip;
        audioSource.Play();

        return CurrentSoundIndex; // 선택된 소리 인덱스 반환
    }

    public void MuteSound()
    {
        audioSource.mute = true;
    }

    public void UnmuteSound()
    {
        audioSource.mute = false;
    }
}
