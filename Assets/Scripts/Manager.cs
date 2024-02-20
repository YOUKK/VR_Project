using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Instance { get { return instance; } }

    void Start()
    {
        
    }

    // 씬 이동 함수
    public void MoveScene(string fromScene, string toScene)
	{
        SceneManager.LoadScene(toScene);
	}
}
