using System.Collections;
using UnityEngine;

public class RandomVisibilityChanger : MonoBehaviour
{
    public GameObject[] objects; // 색을 변경할 세 개의 오브젝트를 할당
    private int lastIndex = -1; // 마지막으로 색이 변경된 오브젝트의 인덱스

    void Start()
    {
        if (objects == null || objects.Length == 0)
        {
            Debug.LogError("Objects array is not set or empty!");
            return;
        }

        // 처음에는 모든 오브젝트를 숨깁니다.
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }

        // 색 변경을 반복적으로 호출
        StartCoroutine(ChangeVisibilityRoutine());
    }

    IEnumerator ChangeVisibilityRoutine()
    {
        while (true)
        {
            if (objects.Length <= 1)
            {
                Debug.LogError("Objects array must contain at least 2 elements.");
                yield break;
            }

            int newIndex = GetRandomIndex();

            // 마지막으로 보였던 오브젝트를 숨깁니다.
            if (lastIndex != -1)
            {
                objects[lastIndex].SetActive(false);
            }

            // 새로운 오브젝트를 보이도록 설정
            objects[newIndex].SetActive(true);

            // 새로운 인덱스를 저장하여 다음 색 변경 시 동일한 오브젝트가 선택되지 않도록 함
            lastIndex = newIndex;

            // 3초 동안 대기
            yield return new WaitForSeconds(3f);
        }
    }

    int GetRandomIndex()
    {
        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, objects.Length);
        } while (randomIndex == lastIndex);

        return randomIndex;
    }
}
