using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI ScriptTxt;
    public GameObject LeftDirectInteractor;
    public GameObject RightDirectInteractor;
    public GameObject LeftRayInteractor;
    public GameObject RightRayInteractor;
    public GameObject TutorialStuff;
    int clickCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "안녕하세요! 저는 당신을 위한 특별한 도우미입니다.\n오늘은 우리 함께 재미있는 미션을 수행해 볼 거에요.";    
    }

    // Update is called once per frame
    public void CntUp()
    {
        Debug.Log(clickCnt);

        clickCnt += 1;
        if(clickCnt == 1)
        {
            ScriptTxt.text = "지시사항에 따라 다양한 미션을 수행하게 될 것입니다.";
        }
        else if (clickCnt == 2)
        {
            ScriptTxt.text = "미션은 물건 정리와 물건 탐색으로 구성되어 있습니다.";
        }
        else if (clickCnt == 3)
        {
            ScriptTxt.text = "그럼 준비가 되었다면 우리 함께 시작해 볼까요?";
        }
        else
        {
            LeftRayInteractor.SetActive(false);
            RightRayInteractor.SetActive(false);
            TutorialStuff.SetActive(false);
        }
    }
}
