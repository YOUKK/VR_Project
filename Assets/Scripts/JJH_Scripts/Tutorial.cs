using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI ScriptTxt;
    public TextMeshProUGUI ButtonTxt1;
    public TextMeshProUGUI ButtonTxt2;
    public TextMeshProUGUI ButtonTxt3;
    public TextMeshProUGUI ButtonTxt4;
    public GameObject LeftDirectInteractor;
    public GameObject RightDirectInteractor;
    public GameObject LeftRayInteractor;
    public GameObject RightRayInteractor;
    public GameObject TutorialStuff;
    public GameObject ButtonStuff;
    int clickCnt = 0;
    bool ButtonFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "안녕하세요! 저는 당신을 위한 특별한 도우미입니다.\n오늘은 우리 함께 재미있는 미션을 수행해 볼 거에요.";
        ButtonTxt1.text = "버튼1";
        ButtonTxt2.text = "버튼2";
        ButtonTxt3.text = "버튼3";
        ButtonTxt4.text = "버튼4";
    }

    // Update is called once per frame
    public void CntUp()
    {
        Debug.Log(clickCnt);
        if(ButtonFlag == false)
        {
            clickCnt += 1;
            switch (clickCnt)
            {
                case 1:
                    ScriptTxt.text = "지시사항에 따라 다양한 미션을 수행하게 될 것입니다.";
                    break;
                case 2:
                    ScriptTxt.text = "미션은 물건 정리와 물건 탐색으로 구성되어 있습니다.";
                    break;
                case 3:
                    ScriptTxt.text = "그럼 준비가 되었다면 우리 함께 시작해 볼까요?";
                    break;
                case 4:
                    ScriptTxt.text = "질문";
                    ButtonFlag = true;
                    ButtonStuff.SetActive(true);
                    break;
                case 5:
                    ScriptTxt.text = "정답";
                    break;
                default:
                    LeftRayInteractor.SetActive(false);
                    RightRayInteractor.SetActive(false);
                    TutorialStuff.SetActive(false);
                    break;
            }
        }
    }

    public void Button1()
    {
        if(clickCnt == 4)
        {
            ScriptTxt.text = "질문\n오답입니다 다시한번 생각해보세요";
        }
    }
    public void Button2()
    {
        if (clickCnt == 4)
        {
            ScriptTxt.text = "질문\n오답입니다 다시한번 생각해보세요";
        }
    }
    public void Button3()
    {
        if (clickCnt == 4)
        {
            ButtonFlag = false;
            ButtonStuff.SetActive(false);
            CntUp();
        }
    }
    public void Button4()
    {
        if (clickCnt == 4)
        {
            ScriptTxt.text = "질문\n오답입니다 다시한번 생각해보세요";
        }
    }
}
