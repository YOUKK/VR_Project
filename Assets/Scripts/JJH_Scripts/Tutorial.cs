using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public GameObject ScriptTxtBox;
    public Sprite newSprite;
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    private int countdownTime = 60;

    private MissionCheck missionCheckScript; // MissionCheck 스크립트 참조

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "안녕하세요!\n저는 당신을 위한 특별한 도우미예요.\n오늘은 재미있는 미션을 수행해 볼 거에요.";
        ButtonTxt1.text = "부엌에서 그릇을\n찬장으로 옮기기";
        ButtonTxt2.text = "부엌에서 음식을\n준비하기";
        ButtonTxt3.text = "부엌에서 식사 도구\n정리하기";
        ButtonTxt4.text = "부엌을 청소하기";

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
                    ScriptTxt.text = "지시사항에 따라 다양한 미션을\n수행하게 될 거예요.";
                    break;
                case 2:
                    ScriptTxt.text = "미션은 물건 정리와 물건 분류로\n구성되어 있어요.";
                    break;
                case 3:
                    ScriptTxt.text = "첫 번째 미션은\n[부엌 안에서 식사 도구 정리하기]예요.";
                    break;
                case 4:
                    ScriptTxt.text = "그럼 준비가 되었다면\n우리 함께 시작해 볼까요?";
                    break;
                case 5:
                    ScriptTxt.text = "여기서 잠깐!\n미션을 이해했는지 확인하려고 해요. \n첫 번째 미션이 무엇인지 선택해주세요.";
                    ButtonFlag = true;
                    ButtonStuff.SetActive(true);
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

                    break;
            }
        }
    }

    public void Button1()
    {
        if(clickCnt == 5)
        {
            ScriptTxt.text = "오답입니다.\n다시한번 생각해보세요";
        }
    }
    public void Button2()
    {
        if (clickCnt == 5)
        {
            ScriptTxt.text = "오답입니다.\n다시한번 생각해보세요";
        }
    }
    public void Button3()
    {
        if (clickCnt == 5)
        {
            ButtonFlag = false;
            ButtonStuff.SetActive(false);
            CntUp();
        }
    }
    public void Button4()
    {
        if (clickCnt == 5)
        {
            ScriptTxt.text = "오답입니다.\n다시한번 생각해보세요";
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

            if (GameObject.Find("dish-drainer").GetComponent<OrganizeDish>().currentTurn == 2 &&
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
