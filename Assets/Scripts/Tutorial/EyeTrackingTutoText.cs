using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EyeTrackingTutoText : MonoBehaviour
{
    public TextMeshProUGUI ScriptTxt;
    public GameObject ScriptTxtBox;
    public Sprite newSprite;
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    public GameObject ResultSuccess;
    public GameObject TutorialStuff;
    public GameObject ResultFail;

    private int clickCnt = 0;
    private bool ButtonFlag = false;
    private int countdownTime = 30;

    void Start()
    {
        ScriptTxt.text = "������ ����ִ� �̼��� ������ ���� �� \n ��� �׽�Ʈ�� �غ�������.";
        CountTxt.text = countdownTime.ToString();
        CountBackground.SetActive(false);
        CountTxt.gameObject.SetActive(false);
    }

    public void CntUp()
    {
        Debug.Log("CntUp called, clickCnt: " + clickCnt);
        if (!ButtonFlag)
        {
            clickCnt += 1;
            Debug.Log("Click Count Incremented: " + clickCnt);
            switch (clickCnt)
            {
                case 1:
                    ScriptTxt.text = "�����ڸ� �����̴� ������ �غ�����.";
                    break;
                case 2:
                    ScriptTxt.text = "�������� �����Ǵ� ť�긦 �ٶ���ּ���.";
                    break;
                case 3:
                    StartCountdown();
                    break;
                default:
                    break;
            }
        }
    }

    void StartCountdown()
    {
        ButtonFlag = true;
        Debug.Log("Countdown Started");

        // CountBackground�� CountTxt�� Ȱ��ȭ�մϴ�.
        CountBackground.SetActive(true);
        CountTxt.gameObject.SetActive(true);

        // ī��Ʈ�ٿ� �ڷ�ƾ�� �����մϴ�.
        StartCoroutine(CountdownTimer());

        // TutorialStuff�� ScriptTxtBox�� ����ϴ�.
        TutorialStuff.SetActive(false);
        ScriptTxtBox.SetActive(false);

        ChangeImage();
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
        Debug.Log("Countdown Timer started"); // �߰��� ����� �α�
        while (countdownTime > 0)
        {
            Debug.Log("Countdown: " + countdownTime); // ����� �α� �߰�
            yield return new WaitForSeconds(1f);
            countdownTime--;
            Debug.Log("Countdown decremented: " + countdownTime); // ����� �α� �߰�
            CountTxt.text = countdownTime.ToString();

            if (countdownTime <= 10)
            {
                StartCoroutine(ShakeText(0.5f, 0.1f));
            }
        }

        Debug.Log("Countdown finished"); // �߰��� ����� �α�

        // Ÿ�̸Ӱ� ������ ���� �޽����� ǥ���մϴ�.
        ResultSuccess.SetActive(true);
        CountBackground.SetActive(false);
        CountTxt.gameObject.SetActive(false);
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
