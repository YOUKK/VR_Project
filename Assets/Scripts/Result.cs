using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField]
    private Button homeButton; // 메인으로 돌아가는 버튼
    [SerializeField]
    private TextMeshProUGUI result_stoptimeDisplay; // 멈춘 시간을 표시할 TextMeshProUGUI 컴포넌트

    void Start()
    {
        homeButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scene_YYJ"); // 홈 버튼 클릭 시 씬 전환
        });

        // PlayerPrefs에서 "StopTimeText" 키를 사용하여 멈춘 시간을 문자열로 불러온다.
        // 저장된 값이 없는 경우 "N/A"를 기본값으로 사용한다.
        string stopTimeText = PlayerPrefs.GetString("StopTimeText", "N/A");

        // 불러온 멈춘 시간을 result_stoptimeDisplay 컴포넌트의 텍스트로 설정한다.
        result_stoptimeDisplay.text = stopTimeText;
    }
}
