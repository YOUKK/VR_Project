using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyAudio : MonoBehaviour
{
    public AudioClip toySound1; // �峭�� �Ҹ�
    public AudioClip toySound2; // ������ �Ҹ�
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
            return -1; // �Ҹ� ���� ����
        }

        CurrentSoundIndex = Random.Range(0, 2);
        AudioClip selectedClip = CurrentSoundIndex == 0 ? toySound1 : toySound2;
        audioSource.clip = selectedClip;
        audioSource.Play();

        return CurrentSoundIndex; // ���õ� �Ҹ� �ε��� ��ȯ
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
