using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial2 : MonoBehaviour
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
    public GameObject Button3_;
    public GameObject Button4_;

    private AudioSource[] audioSources;
    public float delayBetweenSounds = 1.0f;

    public GameObject ResultSuccess;
    public GameObject ResultFail;

    int clickCnt = 0;
    bool ButtonFlag = false;
    public int M2_score1 = 5; // �̼�2 ù ��° ���� ����
    public int M2_score2 = 5; // �̼�2 �� ��° ���� ����
    public int M2_score = 0; // �̼�2 �� ����

    public GameObject ScriptTxtBox;
    public Sprite newSprite;
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    private int countdownTime = 20;

    public Mission2 mission2Script; // Mission2 ��ũ��Ʈ�� ���� ���� �ʵ� 

    [SerializeField]
    private Animator birdAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "���� �� ��° �̼��� �˷��帱�Կ�.\n�� ��° �̼��� [�Ҹ��� �ش��ϴ� �峭�� �з��ϱ�]����.";
        ButtonTxt1.text = "������ �ٱ���";
        ButtonTxt2.text = "�Ķ��� �ٱ���";
        ButtonTxt3.text = "���� ���� �Ҹ�";
        ButtonTxt4.text = "�� ���� �Ҹ�";

        audioSources = this.gameObject.GetComponents<AudioSource>();

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
                    ScriptTxt.text = "���� �ٱ��Ͽ��� ���� ������ �ְ�\n �Ķ� �ٱ��Ͽ��� ���� ������ �ƴ� �峭���� �־��ּ���.";
                    break;
                case 2:
                    ScriptTxt.text = "���� �峭�� �Ҹ��� �ƴ� ������� �鸮��\n �ش� �峭���� �ٱ��Ͽ� ���� ������.";
                    break;
                case 3:
                    ScriptTxt.text = "�׷� �غ� �Ǿ��ٸ� �츮 �Բ� ������ �����?\n";
                    break;
                case 4:
                    ScriptTxt.text = "���⼭ ���!\n�̼��� �����ߴ��� Ȯ���Ϸ��� �ؿ�. \n������ ��� �ʿ� �з��ϸ� �ɱ��?";
                    ButtonFlag = true;
                    ButtonStuff.SetActive(true);
                    break;
                case 5:
                    ScriptTxt.text = "�����Դϴ�.\n�� ������ � �Ҹ��� �鸮�� ��������� �߳���?";
                    ButtonFlag = true;
                    ButtonTxt1.text = "�� ���� �Ҹ�";
                    ButtonTxt2.text = "����� �Ҹ�";
                    Button3_.SetActive(true);
                    Button4_.SetActive(true);
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

                    StartCoroutine(mission2Script.ActivateToysRandomly()); // ���⼭ ����

                    break;
            }
        }
        if(ButtonFlag == true && clickCnt == 5)
        {
            StartCoroutine(PlaySoundsSequentially());
        }
    }

    public void Button1()
    {
        if (clickCnt == 5)
        {
            if (M2_score2 > 0) M2_score2 -= 1;
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
            Debug.Log("M2_score2: " + M2_score2);
            birdAnimator.SetTrigger("No");
        }
        if (clickCnt == 4)
        {
            if (M2_score1 > 0) M2_score1 -= 1;
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
            Debug.Log("M2_score1: " + M2_score1);
            birdAnimator.SetTrigger("No");
        }
    }
    public void Button2()
    {
        if (clickCnt == 5)
        {
            ButtonFlag = false;
            ButtonStuff.SetActive(false);
            birdAnimator.SetTrigger("Happy");
            CntUp();
            Debug.Log("M2_score2: " + M2_score2);
        }
        if (clickCnt == 4)
        {
            ButtonFlag = false;
            birdAnimator.SetTrigger("Happy");
            CntUp();
            Debug.Log("M2_score1: " + M2_score1);
        }
    }
    public void Button3()
    {
        if (clickCnt == 5)
        {
            if (M2_score2 > 0) M2_score2 -= 1;
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
            Debug.Log("M2_score2: " + M2_score2);
            birdAnimator.SetTrigger("No");
        }
    }
    public void Button4()
    {
        if (clickCnt == 5)
        {
            if (M2_score2 > 0) M2_score2 -= 1;
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
            Debug.Log("M2_score2: " + M2_score2);
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

    IEnumerator PlaySoundsSequentially()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
            // �Ҹ��� ����Ǵ� ���� ��ٸ�
            while (audioSource.isPlaying)
            {
                yield return null; // ���� �����ӱ��� ���
            }
            yield return new WaitForSeconds(delayBetweenSounds);
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

            /*if (GameObject.Find("dish-drainer").GetComponent<OrganizeDish>().currentTurn == 2 &&
                GameObject.Find("knife-block").GetComponent<OrganizeKnife>().currentTurn == 0 &&
                GameObject.Find("Sink").GetComponent<OrganizeSpoonFork>().currentTurn == 0)
            {
                ResultSuccess.SetActive(true);
                Debug.Log("����");
                Debug.Log(countdownTime);
                CountBackground.SetActive(false);
                CountTxt.gameObject.SetActive(false);
                break;
            }
            if (countdownTime == 0)
            {
                ResultFail.SetActive(true);
                Debug.Log("����");
                CountBackground.SetActive(false);
                CountTxt.gameObject.SetActive(false);

            }*/

        }
        M2_score = M2_score1 + M2_score2;
        Debug.Log("�� ���� (M2_score): " + M2_score);
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
