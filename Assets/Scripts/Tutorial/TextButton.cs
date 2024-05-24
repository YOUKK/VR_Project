using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextButton : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    private GameObject rayLeft;
    [SerializeField]
    private GameObject rayRight;
    [SerializeField]
    private GameObject rand; // rand 오브젝트를 추가로 인자로 받습니다.

    public void OnClicked()
    {
        // 텍스트 버튼 오브젝트 비활성화
        gameObject.SetActive(false);
        // 새 오브젝트 비활성화
        bird.SetActive(false);
        // ray달린 손 비활성화
        rayLeft.SetActive(false);
        rayRight.SetActive(false);

        // rand 오브젝트 활성화
        rand.SetActive(true);
    }
}
