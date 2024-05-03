using UnityEngine;

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
            DontDestroyOnLoad(gameObject); // GameObject를 씬 전환 시 파괴되지 않도록 함
            InitializeAudio();
        }
        else
        {
            Destroy(gameObject);
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
}
