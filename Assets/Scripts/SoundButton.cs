using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button increasedButton;
    [SerializeField] private Button decreasedButton;
    [SerializeField] private RectTransform autoBar;
    [SerializeField] private Button muteButton;
    [SerializeField] private Button unmuteButton;

    private float volumeStep = 0.1f; //���� ���� ����
    private float moveStep = 24f; //autoBar �̵� ����
    private int volumeLevel = 0; //���� ����/�̵� �ܰ� (0���� �����Ͽ� +5 �Ǵ� -5����)
    private const int maxLevel = 5; //�ִ� ����/�̵� �ܰ�

    private float savedVolume = 0;  //������ ������ ����

    void Start()
    {
        increasedButton.onClick.AddListener(() => {
            if (volumeLevel < maxLevel)
            {
                IncreaseVolume();
                MoveBar(moveStep);
                volumeLevel++;
            }
        });

        decreasedButton.onClick.AddListener(() => {
            if (volumeLevel > -maxLevel)
            {
                DecreaseVolume();
                MoveBar(-moveStep);
                volumeLevel--;
            }
        });

        homeButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Scene_MainTitle");
        });

        muteButton.onClick.AddListener(MuteVolume);
        unmuteButton.onClick.AddListener(UnmuteVolume);

        // ���� ���Ұ� ���¿� ���� ��ư Ȱ��ȭ/��Ȱ��ȭ ����
        if (Sound.Instance.isMuted)
        {
            muteButton.gameObject.SetActive(false);
            unmuteButton.gameObject.SetActive(true);
        }
        else
        {
            muteButton.gameObject.SetActive(true);
            unmuteButton.gameObject.SetActive(false);
        }
    }

    void IncreaseVolume()
    {
        if (Sound.Instance != null)
        {
            float newVolume = Sound.Instance.GetComponent<AudioSource>().volume + volumeStep;
            if (newVolume > 1) newVolume = 1; // �ִ� ������ 1�� ����
            Sound.Instance.SetVolume(newVolume);
        }
    }

    void DecreaseVolume()
    {
        if (Sound.Instance != null)
        {
            float newVolume = Sound.Instance.GetComponent<AudioSource>().volume - volumeStep;
            if (newVolume < 0) newVolume = 0; // �ּ� ������ 0���� ����
            Sound.Instance.SetVolume(newVolume);
        }
    }

    void MoveBar(float step)
    {
        Vector3 position = autoBar.localPosition;
        position.x += step; // X ���� ���� �̵�
        autoBar.localPosition = position;
    }

    public void MuteVolume()
    {
        if (Sound.Instance != null)
        {
            if (!Sound.Instance.isMuted)
            {
                Sound.Instance.GetComponent<AudioSource>().Pause(); // ����� �Ͻ�����
                Sound.Instance.isMuted = true;
                muteButton.gameObject.SetActive(false);
                unmuteButton.gameObject.SetActive(true);
            }
        }
    }

    public void UnmuteVolume()
    {
        if (Sound.Instance != null)
        {
            if (Sound.Instance.isMuted)
            {
                Sound.Instance.GetComponent<AudioSource>().Play(); // ����� ��� �簳
                Sound.Instance.isMuted = false;
                unmuteButton.gameObject.SetActive(false);
                muteButton.gameObject.SetActive(true);
            }
        }
    }

}
