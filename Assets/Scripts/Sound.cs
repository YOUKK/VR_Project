using UnityEngine;
using UnityEngine.SceneManagement; 

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
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // "GAME2" �������� ������ 1�� ����
        if (scene.name == "Game2")
        {
            SetVolume(0f);
        }
        else
        {
            SetVolume(savedVolume); // �ٸ� �������� ������ ����� ������ ���
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
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
