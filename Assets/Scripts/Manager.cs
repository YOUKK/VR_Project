using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 여러 스크립트에서 사용되는 속성, 기능을 모아두는 스크립트
public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Instance { get { return instance; } }

    public static HandType curHandType = HandType.Left;
    public static bool isRightGrab = false; // 오른손이 grab중이면 true
    public static bool isLeftGrab = false; // 왼손이 grab중이면 true

    void Start()
    {
        
    }

    public static void IsGrabSet(HandType handType, bool isGrab)
	{
        curHandType = handType;

        if (handType == HandType.Left)
            isLeftGrab = isGrab;
        else
            isRightGrab = isGrab;

        Debug.Log(handType + " " + isLeftGrab.ToString() + " " + isRightGrab.ToString());
	}

    public static bool IsGrabGet()
	{
        if (curHandType == HandType.Left)
            return isLeftGrab;
        else
            return isRightGrab;
	}

    // 씬 이동 함수
    public void MoveScene(string fromScene, string toScene)
	{
        SceneManager.LoadScene(toScene);
	}
}
