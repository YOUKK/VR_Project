using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.Serialization;

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
    //public GameObject ResultStuff;

    public GameObject ResultSuccess;
    public GameObject ResultFail;


    int clickCnt = 0;
    bool ButtonFlag = false;
    public int M1_score = 8;

    public GameObject ScriptTxtBox;
    public Sprite newSprite;
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    private int countdownTime = 90;

    private MissionCheck missionCheckScript; // MissionCheck ��ũ��Ʈ ����

    [SerializeField]
    private Animator birdAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "�ȳ��ϼ���!\n���� ����� ���� Ư���� ����̿���.\n������ ����ִ� �̼��� ������ �� �ſ���.";
        ButtonTxt1.text = "�ξ����� �׸���\n�������� �ű��";
        ButtonTxt2.text = "�ξ����� ����\n�غ��ϱ�";
        ButtonTxt3.text = "�ξ����� �Ļ� ����\n�����ϱ�";
        ButtonTxt4.text = "�ξ��� û���ϱ�";

        CountTxt.text = countdownTime.ToString();
        CountBackground.SetActive(false);
        CountTxt.gameObject.SetActive(false);

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
                    ScriptTxt.text = "���û��׿� ���� �پ��� �̼���\n�����ϰ� �� �ſ���.";
                    break;
                case 2:
                    ScriptTxt.text = "�̼��� ���� ������ ���� �з���\n�����Ǿ� �־��.";
                    break;
                case 3:
                    ScriptTxt.text = "ù ��° �̼���\n[�ξ� �ȿ��� �Ļ� ���� �����ϱ�]����.";
                    break;
                case 4:
                    ScriptTxt.text = "�׷� �غ� �Ǿ��ٸ�\n�츮 �Բ� ������ �����?";
                    break;
                case 5:
                    ScriptTxt.text = "���⼭ ���!\n�̼��� �����ߴ��� Ȯ���Ϸ��� �ؿ�. \nù ��° �̼��� �������� �������ּ���.";
                    ButtonFlag = true;
                    ButtonStuff.SetActive(true);
                    break;
                case 6:
                    ScriptTxt.text = "�����Դϴ�.\n���� �����غ����?";
                    break;
                default:
                    LeftRayInteractor.SetActive(false);
                    RightRayInteractor.SetActive(false);
                    TutorialStuff.SetActive(false);

                    CountBackground.SetActive(true);
                    StartCoroutine(CountdownTimer());
                    ScriptTxt.text = " ";
                    CountTxt.gameObject.SetActive(true);
                    ChangeImage();

                    break;
            }
        }
    }

    public void Button1()
    {
        if(clickCnt == 5)
        {
            if (M1_score > 0) M1_score -= 1;
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
            M1_score--;
            TotalResult.clickNum++;
            Debug.Log("M1_score:" + M1_score);
            birdAnimator.SetTrigger("No");
        }
    }
    public void Button2()
    {
        if (clickCnt == 5)
        {
            if (M1_score > 0) M1_score -= 1;
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
            M1_score--;
            TotalResult.clickNum++;
            Debug.Log("M1_score:" + M1_score);
            birdAnimator.SetTrigger("No");
        }
    }
    public void Button3()
    {
        if (clickCnt == 5)
        {
            ButtonFlag = false;
            ButtonStuff.SetActive(false);
            Debug.Log("M1_score:" + M1_score);
            birdAnimator.SetTrigger("Happy");
            TotalResult.clickNum++;

            // ���� ���߸� TotalResult�� �� ����
            TotalResult.mission1Quiz = M1_score;

            CntUp();
        }
    }
    public void Button4()
    {
        if (clickCnt == 5)
        {
            if (M1_score > 0) M1_score -= 1;
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
            M1_score--;
            TotalResult.clickNum++;
            Debug.Log("M1_score:" + M1_score);
            birdAnimator.SetTrigger("No");
        }
    }
    void ChangeImage()
    {
        Image textBoxImage = ScriptTxtBox.GetComponent<Image>();
        if (textBoxImage != null)
        {
            textBoxImage.sprite = newSprite;
        }
        else
        {
            Debug.LogError("ScriptTxtBox�� Image ������Ʈ�� �����ϴ�.");
        }
    }

    IEnumerator CountdownTimer()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            CountTxt.text = countdownTime.ToString();

            if (countdownTime <= 10)
            {
                StartCoroutine(ShakeText(0.5f, 0.1f));
            }

            if (GameObject.Find("dish-drainer").GetComponent<OrganizeDish>().currentTurn == 5 &&
                GameObject.Find("knife-block").GetComponent<OrganizeKnife>().currentTurn == 5 &&
                GameObject.Find("Sink").GetComponent<OrganizeSpoonFork>().forkNum == 5 &&
                GameObject.Find("Sink").GetComponent<OrganizeSpoonFork>().spoonNum == 5)
            {
                ResultSuccess.SetActive(true);
                Debug.Log("����");
                Debug.Log(countdownTime);
                CountBackground.SetActive(false);
                CountTxt.gameObject.SetActive(false);
                TotalResult.mission1CorrectItem = GameObject.Find("dish-drainer").GetComponent<OrganizeDish>().currentTurn +
                                                  GameObject.Find("knife-block").GetComponent<OrganizeKnife>().currentTurn +
                                                  GameObject.Find("Sink").GetComponent<OrganizeSpoonFork>().currentTurn;

                //5�ʵ� ����ȯ
                yield return new WaitForSeconds(5f);
                SceneManager.LoadScene("Game2");
            }
            if (countdownTime == 0)
            {
                ResultFail.SetActive(true);
                Debug.Log("����");
                CountBackground.SetActive(false);
                CountTxt.gameObject.SetActive(false);
                TotalResult.mission1CorrectItem = GameObject.Find("dish-drainer").GetComponent<OrganizeDish>().currentTurn +
                                                  GameObject.Find("knife-block").GetComponent<OrganizeKnife>().currentTurn +
                                                  GameObject.Find("Sink").GetComponent<OrganizeSpoonFork>().currentTurn;

                //5�ʵ� ����ȯ
                yield return new WaitForSeconds(5f);
                SceneManager.LoadScene("Game2");
            }
        }
        Debug.Log("�� ����(M1_score):" + M1_score);
    }

    IEnumerator ShakeText(float duration, float magnitude)
    {
        Vector3 originalPos = CountTxt.transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-5f, 5f) * magnitude;
            float y = Random.Range(-5f, 5f) * magnitude;
            CountTxt.transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        CountTxt.transform.localPosition = originalPos;
    }

}
