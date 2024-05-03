using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI CountTxt;
    public GameObject CountBackground;
    private int countdownTime = 60; // ������ ī��Ʈ�ٿ� �ð�

    void Start()
    {
        CountTxt.text = countdownTime.ToString(); // �ʱ� �ð� ����
        StartCoroutine(CountdownTimer()); // ī��Ʈ�ٿ� ����
    }

    IEnumerator CountdownTimer()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f); // 1�� ���
            countdownTime--; // �ð� ����
            CountTxt.text = countdownTime.ToString(); // UI ������Ʈ
        }

        // �ð��� 0�ʿ� �����ϸ� �޽��� ǥ��
        CountTxt.text = "����";
    }
}