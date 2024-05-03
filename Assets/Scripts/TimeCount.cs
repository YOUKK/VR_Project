using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    private int countdownTime = 60; // 시작할 카운트다운 시간

    void Start()
    {
        CountTxt.text = countdownTime.ToString(); // 초기 시간 설정
        StartCoroutine(CountdownTimer()); // 카운트다운 시작
    }

    IEnumerator CountdownTimer()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f); // 1초 대기
            countdownTime--; // 시간 감소
            CountTxt.text = countdownTime.ToString(); // UI 업데이트
        }

        // 시간이 0초에 도달하면 메시지 표시
        CountTxt.text = "종료";
    }
}