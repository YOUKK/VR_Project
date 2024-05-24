using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EyeTrackingTutorialStuff : MonoBehaviour
{
    public TextMeshProUGUI ScriptTxt;
    public TextMeshProUGUI ButtonTxt1;
    public TextMeshProUGUI ButtonTxt2;
    public GameObject LeftDirectInteractor;
    public GameObject RightDirectInteractor;
    public GameObject LeftRayInteractor;
    public GameObject RightRayInteractor;
    public GameObject TutorialStuff;
    public GameObject ButtonStuff;

    private AudioSource[] audioSources;
    public float delayBetweenSounds = 1.0f;

    public GameObject ResultSuccess;
    public GameObject ResultFail;

    int clickCnt = 0;
    bool ButtonFlag = false;

    public GameObject ScriptTxtBox;
    public Sprite newSprite;
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    private int countdownTime = 20;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "���� �� ��° �̼��� �˷��帱�Կ�.\n�� ��° �̼��� [�Ҹ��� �ش��ϴ� �峭�� �з��ϱ�]����.";
        ButtonTxt1.text = "����";
        ButtonTxt2.text = "������";
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
        if (ButtonFlag == false)
        {
            clickCnt += 1;
            switch (clickCnt)
            {
                case 1:
                    ScriptTxt.text = "���� ���� �Ҹ��� �鸮��\n�ش� ������ ������ �ٱ��Ͽ� �з��ϰ�";
                    break;
                case 2:
                    ScriptTxt.text = "��ȣ���� �鸮��\n �ش� ������ ������ �ٱ��Ͽ� �з��ϼ���\n";
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
        if (ButtonFlag == true && clickCnt == 5)
        {
            StartCoroutine(PlaySoundsSequentially());
        }
    }

    public void Button1()
    {
        if (clickCnt == 5)
        {
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
        }
        if (clickCnt == 4)
        {
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
        }
    }
    public void Button2()
    {
        if (clickCnt == 5)
        {
            ButtonFlag = false;
            ButtonStuff.SetActive(false);
            CntUp();
        }
        if (clickCnt == 4)
        {
            ButtonFlag = false;
            CntUp();
        }
    }
    public void Button3()
    {
        if (clickCnt == 5)
        {
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
        }
    }
    public void Button4()
    {
        if (clickCnt == 5)
        {
            ScriptTxt.text = "�����Դϴ�. �ٽ��ѹ� �����غ�����";
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



        }
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
