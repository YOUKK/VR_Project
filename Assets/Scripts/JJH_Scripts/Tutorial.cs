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
        ScriptTxt.text = "�ȳ��ϼ���! ���� ����� ���� Ư���� ������Դϴ�.\n������ �츮 �Բ� ����ִ� �̼��� ������ �� �ſ���.";
        ButtonTxt1.text = "��ư1";
        ButtonTxt2.text = "��ư2";
        ButtonTxt3.text = "��ư3";
        ButtonTxt4.text = "��ư4";
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
                    ScriptTxt.text = "���û��׿� ���� �پ��� �̼��� �����ϰ� �� ���Դϴ�.";
                    break;
                case 2:
                    ScriptTxt.text = "�̼��� ���� ������ ���� Ž������ �����Ǿ� �ֽ��ϴ�.";
                    break;
                case 3:
                    ScriptTxt.text = "�׷� �غ� �Ǿ��ٸ� �츮 �Բ� ������ �����?";
                    break;
                case 4:
                    ScriptTxt.text = "����";
                    ButtonFlag = true;
                    ButtonStuff.SetActive(true);
                    break;
                case 5:
                    ScriptTxt.text = "����";
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
            ScriptTxt.text = "����\n�����Դϴ� �ٽ��ѹ� �����غ�����";
        }
    }
    public void Button2()
    {
        if (clickCnt == 4)
        {
            ScriptTxt.text = "����\n�����Դϴ� �ٽ��ѹ� �����غ�����";
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
            ScriptTxt.text = "����\n�����Դϴ� �ٽ��ѹ� �����غ�����";
        }
    }
}
