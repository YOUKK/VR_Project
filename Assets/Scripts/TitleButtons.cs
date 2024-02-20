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
    private Button ruleButton; // 게임방법 버튼
    [SerializeField]
    private Button settingButton; // 설정 버튼
    [SerializeField]
    private Button exitButton; // 나가기 버튼

    void Start()
    {
        //startButton.onClick.AddListener(() => Manager.Instance.MoveScene("Scene_KYK", "Scenario1"));
        startButton.onClick.AddListener(() => SceneManager.LoadScene("Scenario1"));
    }

    void Update()
    {
        
    }


}
