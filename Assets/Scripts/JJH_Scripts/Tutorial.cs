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
        ScriptTxt.text = "�ȳ��ϼ���! ���� ����� ���� Ư���� ������Դϴ�.\n������ �츮 �Բ� ����ִ� �̼��� ������ �� �ſ���.";    
    }

    // Update is called once per frame
    public void CntUp()
    {
        Debug.Log(clickCnt);

        clickCnt += 1;
        if(clickCnt == 1)
        {
            ScriptTxt.text = "���û��׿� ���� �پ��� �̼��� �����ϰ� �� ���Դϴ�.";
        }
        else if (clickCnt == 2)
        {
            ScriptTxt.text = "�̼��� ���� ������ ���� Ž������ �����Ǿ� �ֽ��ϴ�.";
        }
        else if (clickCnt == 3)
        {
            ScriptTxt.text = "�׷� �غ� �Ǿ��ٸ� �츮 �Բ� ������ �����?";
        }
        else
        {
            LeftRayInteractor.SetActive(false);
            RightRayInteractor.SetActive(false);
            TutorialStuff.SetActive(false);
        }
    }
}
