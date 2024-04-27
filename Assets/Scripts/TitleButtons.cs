using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 타이틀씬에 있는 버튼들의 기능을 정의하는 스크립트
public class TitleButtons : MonoBehaviour
{
    [SerializeField]
    private Button startButton; // 시작하기 버튼
    [SerializeField]
    private Button ruleButton; // 튜토리얼 버튼
    [SerializeField]
    private Button settingButton; // 소리 설정 버튼
    [SerializeField]
    private Button exitButton; // 나가기 버튼
    [SerializeField]
    private GameObject logo;

    void Start()
    {
        //startButton.onClick.AddListener(() => Manager.Instance.MoveScene("Scene_KYK", "Scenario1"));
        startButton.onClick.AddListener(() => {
            Debug.Log("button 테스트");
            SceneManager.LoadScene("Game");
        });

        settingButton.onClick.AddListener(() => {
            SceneManager.LoadScene("Scene_SoundSetting");
        });


        //StartCoroutine(LeanAnimation()); //로고 애니메이션 효과
    }

    /*IEnumerator LeanAnimation()
    {
        float scaleSpeed = 3f; // 스케일 변화 속도
        float maxScale = 1.05f; // 최대 스케일
        float minScale = 1.0f; // 최소 스케일

        while (true)
        {
            float time = Mathf.Sin(Time.time * scaleSpeed) * 0.5f + 0.5f;
            float scale = Mathf.Lerp(minScale, maxScale, time);
            logo.transform.localScale = new Vector3(scale, scale, scale);

            yield return null;
        }
    }*/
}
