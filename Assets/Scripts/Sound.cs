using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위한 네임스페이스 추가

public class Sound : MonoBehaviour
{
    public static Sound Instance;
    public float savedVolume = 1.0f;
    public bool isMuted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudio();
            SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때 호출될 이벤트에 메소드 연결
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // "GAME" 씬에서만 볼륨을 1로 설정
        if (scene.name == "Game")
        {
            SetVolume(0f);
        }
        else
        {
            SetVolume(savedVolume); // 다른 씬에서는 이전에 저장된 볼륨을 사용
        }
    }

    public void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
        savedVolume = volume;
        isMuted = volume == 0;
    }

    public void InitializeAudio()
    {
        if (isMuted)
            GetComponent<AudioSource>().volume = 0;
        else
            GetComponent<AudioSource>().volume = savedVolume;
    }

    void OnDestroy()
    {
        // 이벤트 연결 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
