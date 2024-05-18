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

    private float volumeStep = 0.1f; //볼륨 조절 단위
    private float moveStep = 24f; //autoBar 이동 단위
    private int volumeLevel = 0; //현재 볼륨/이동 단계 (0에서 시작하여 +5 또는 -5까지)
    private const int maxLevel = 5; //최대 볼륨/이동 단계

    private float savedVolume = 0;  //볼륨을 저장할 변수

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

        // 현재 음소거 상태에 따라 버튼 활성화/비활성화 설정
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
            if (newVolume > 1) newVolume = 1; // 최대 볼륨을 1로 제한
            Sound.Instance.SetVolume(newVolume);
        }
    }

    void DecreaseVolume()
    {
        if (Sound.Instance != null)
        {
            float newVolume = Sound.Instance.GetComponent<AudioSource>().volume - volumeStep;
            if (newVolume < 0) newVolume = 0; // 최소 볼륨을 0으로 제한
            Sound.Instance.SetVolume(newVolume);
        }
    }

    void MoveBar(float step)
    {
        Vector3 position = autoBar.localPosition;
        position.x += step; // X 축을 따라 이동
        autoBar.localPosition = position;
    }

    public void MuteVolume()
    {
        if (Sound.Instance != null)
        {
            if (!Sound.Instance.isMuted)
            {
                Sound.Instance.GetComponent<AudioSource>().Pause(); // 오디오 일시정지
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
                Sound.Instance.GetComponent<AudioSource>().Play(); // 오디오 재생 재개
                Sound.Instance.isMuted = false;
                unmuteButton.gameObject.SetActive(false);
                muteButton.gameObject.SetActive(true);
            }
        }
    }

}
