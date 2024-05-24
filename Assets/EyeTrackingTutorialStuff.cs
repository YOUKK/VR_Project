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
        ScriptTxt.text = "이제 두 번째 미션을 알려드릴게요.\n두 번째 미션은 [소리에 해당하는 장난감 분류하기]예요.";
        ButtonTxt1.text = "왼쪽";
        ButtonTxt2.text = "오른쪽";
        ButtonTxt3.text = "오리 울음 소리";
        ButtonTxt4.text = "소 울음 소리";

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
                    ScriptTxt.text = "동물 울음 소리가 들리면\n해당 동물은 오른쪽 바구니에 분류하고";
                    break;
                case 2:
                    ScriptTxt.text = "신호음이 들리면\n 해당 동물을 오른쪽 바구니에 분류하세요\n";
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
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
        }
        if (clickCnt == 4)
        {
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
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
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
        }
    }
    public void Button4()
    {
        if (clickCnt == 5)
        {
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
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

    IEnumerator PlaySoundsSequentially()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
            // 소리가 재생되는 동안 기다림
            while (audioSource.isPlaying)
            {
                yield return null; // 다음 프레임까지 대기
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
