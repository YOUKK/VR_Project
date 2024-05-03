using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance; // 싱글톤 인스턴스
    public float savedVolume = 1.0f; // 음소거 전 볼륨을 저장
    public bool isMuted = false; // 음소거 상태

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 이 GameObject를 씬 전환 시 파괴되지 않도록 설정
            InitializeAudio();
        }
        else
        {
            Destroy(gameObject); // 중복 인스턴스 파괴
        }
    }

    public void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume; // 볼륨 설정
        savedVolume = volume; // 현재 볼륨 저장
        isMuted = volume == 0; // 볼륨이 0이면 음소거로 간주
    }

    public void InitializeAudio()
    {
        if (isMuted)
            GetComponent<AudioSource>().volume = 0;
        else
            GetComponent<AudioSource>().volume = savedVolume;
    }
}
