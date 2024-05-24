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
        InitializeTutorial();
    }

    void InitializeTutorial()
    {
        ScriptTxt.text = "눈동자만 움직여보는 연습을 해볼께요";
        ButtonTxt1.text = "예";
        ButtonTxt2.text = "아니요";
        clickCnt = 0;
        ButtonFlag = false;

        CountTxt.text = countdownTime.ToString();
        CountBackground.SetActive(false);
        CountTxt.gameObject.SetActive(false);
        ButtonStuff.SetActive(true);
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
                    ScriptTxt.text = "눈앞에 생기는 네모를 눈으로만 따라가주세요.";
                    break;
                case 2:
                    ScriptTxt.text = "그럼 준비 되었나요?";
                    ButtonStuff.SetActive(true);
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
        if (clickCnt == 2)
        {
            ButtonFlag = false;
            ButtonStuff.SetActive(false);
            CntUp();
        }
    }

    public void Button2()
    {
        if (clickCnt == 2)
        {
            ButtonFlag = false;
            ButtonStuff.SetActive(false);
            InitializeTutorial();
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
            Debug.LogError("ScriptTxtBox에 Image 컴포넌트가 없습니다.");
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

        // 타이머가 끝났을 때 결과 표시
        ShowResult();
    }

    void ShowResult()
    {
        if (countdownTime <= 0)
        {
            ResultFail.SetActive(true);
        }
        else
        {
            ResultSuccess.SetActive(true);
        }

        // 일정 시간 후에 결과를 숨기고 초기화
        StartCoroutine(HideResultAfterDelay(3f));
    }

    IEnumerator HideResultAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResultFail.SetActive(false);
        ResultSuccess.SetActive(false);
        InitializeTutorial();
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
