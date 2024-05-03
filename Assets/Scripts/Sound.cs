using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance; // �̱��� �ν��Ͻ�
    public float savedVolume = 1.0f; // ���Ұ� �� ������ ����
    public bool isMuted = false; // ���Ұ� ����

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� GameObject�� �� ��ȯ �� �ı����� �ʵ��� ����
            InitializeAudio();
        }
        else
        {
            Destroy(gameObject); // �ߺ� �ν��Ͻ� �ı�
        }
    }

    public void SetVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume; // ���� ����
        savedVolume = volume; // ���� ���� ����
        isMuted = volume == 0; // ������ 0�̸� ���Ұŷ� ����
    }

    public void InitializeAudio()
    {
        if (isMuted)
            GetComponent<AudioSource>().volume = 0;
        else
            GetComponent<AudioSource>().volume = savedVolume;
    }
}
