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
        ScriptTxt.text = "오늘은 재미있는 미션을 수행해 보기 전 \n 잠시 테스트를 해볼꺼에요.";
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
                    ScriptTxt.text = "눈동자만 움직이는 연습을 해볼께요.";
                    break;
                case 2:
                    ScriptTxt.text = "랜덤으로 생성되는 큐브를 바라봐주세요.";
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

        // CountBackground와 CountTxt를 활성화합니다.
        CountBackground.SetActive(true);
        CountTxt.gameObject.SetActive(true);

        // 카운트다운 코루틴을 시작합니다.
        StartCoroutine(CountdownTimer());

        // TutorialStuff와 ScriptTxtBox를 숨깁니다.
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
            Debug.LogError("ScriptTxtBox에 Image 컴포넌트가 없습니다.");
        }
    }

    IEnumerator CountdownTimer()
    {
        Debug.Log("Countdown Timer started"); // 추가된 디버그 로그
        while (countdownTime > 0)
        {
            Debug.Log("Countdown: " + countdownTime); // 디버그 로그 추가
            yield return new WaitForSeconds(1f);
            countdownTime--;
            Debug.Log("Countdown decremented: " + countdownTime); // 디버그 로그 추가
            CountTxt.text = countdownTime.ToString();

            if (countdownTime <= 10)
            {
                StartCoroutine(ShakeText(0.5f, 0.1f));
            }
        }

        Debug.Log("Countdown finished"); // 추가된 디버그 로그

        // 타이머가 끝나면 성공 메시지를 표시합니다.
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
