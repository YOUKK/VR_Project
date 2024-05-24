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
    public int M2_score1 = 5; // 미션2 첫 번째 질문 점수
    public int M2_score2 = 5; // 미션2 두 번째 질문 점수
    public int M2_score = 0; // 미션2 총 점수

    public GameObject ScriptTxtBox;
    public Sprite newSprite;
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    private int countdownTime = 20;

    public Mission2 mission2Script; // Mission2 스크립트를 참조 위한 필드 

    [SerializeField]
    private Animator birdAnimator;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "이제 두 번째 미션을 알려드릴게요.\n두 번째 미션은 [소리에 해당하는 장난감 분류하기]예요.";
        ButtonTxt1.text = "빨간색 바구니";
        ButtonTxt2.text = "파란색 바구니";
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
        if(ButtonFlag == false)
        {
            clickCnt += 1;
            switch (clickCnt)
            {
                case 1:
                    ScriptTxt.text = "빨간 바구니에는 동물 인형을 넣고\n 파란 바구니에는 동물 인형이 아닌 장난감을 넣어주세요.";
                    break;
                case 2:
                    ScriptTxt.text = "만약 장난감 소리가 아닌 경고음이 들리면\n 해당 장난감을 바구니에 넣지 마세요.";
                    break;
                case 3:
                    ScriptTxt.text = "그럼 준비가 되었다면 우리 함께 시작해 볼까요?\n";
                    break;
                case 4:
                    ScriptTxt.text = "여기서 잠깐!\n미션을 이해했는지 확인하려고 해요. \n동물을 어느 쪽에 분류하면 될까요?";
                    ButtonFlag = true;
                    ButtonStuff.SetActive(true);
                    break;
                case 5:
                    ScriptTxt.text = "정답입니다.\n그 다음은 어떤 소리가 들리면 넣지말라고 했나요?";
                    ButtonFlag = true;
                    ButtonTxt1.text = "양 울음 소리";
                    ButtonTxt2.text = "경고음 소리";
                    Button3_.SetActive(true);
                    Button4_.SetActive(true);
                    break;
                case 6:
                    ScriptTxt.text = "정답입니다.\n이제 시작해볼까요?";
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

                    StartCoroutine(mission2Script.ActivateToysRandomly()); // 여기서 시작

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
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
            Debug.Log("M2_score2: " + M2_score2);
            birdAnimator.SetTrigger("No");
        }
        if (clickCnt == 4)
        {
            if (M2_score1 > 0) M2_score1 -= 1;
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
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
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
            Debug.Log("M2_score2: " + M2_score2);
            birdAnimator.SetTrigger("No");
        }
    }
    public void Button4()
    {
        if (clickCnt == 5)
        {
            if (M2_score2 > 0) M2_score2 -= 1;
            ScriptTxt.text = "오답입니다. 다시한번 생각해보세요";
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

            /*if (GameObject.Find("dish-drainer").GetComponent<OrganizeDish>().currentTurn == 2 &&
                GameObject.Find("knife-block").GetComponent<OrganizeKnife>().currentTurn == 0 &&
                GameObject.Find("Sink").GetComponent<OrganizeSpoonFork>().currentTurn == 0)
            {
                ResultSuccess.SetActive(true);
                Debug.Log("성공");
                Debug.Log(countdownTime);
                CountBackground.SetActive(false);
                CountTxt.gameObject.SetActive(false);
                break;
            }
            if (countdownTime == 0)
            {
                ResultFail.SetActive(true);
                Debug.Log("실패");
                CountBackground.SetActive(false);
                CountTxt.gameObject.SetActive(false);

            }*/

        }
        M2_score = M2_score1 + M2_score2;
        Debug.Log("총 점수 (M2_score): " + M2_score);
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
