using System.Collections;
using UnityEngine;

public class RandomVisibilityChanger : MonoBehaviour
{
    public GameObject[] objects;
    private int lastIndex = -1;

    void Awake()
    {
        // 처음에는 모든 오브젝트를 숨깁니다.
        if (objects != null && objects.Length > 0)
        {
            foreach (var obj in objects)
            {
                obj.SetActive(false);
            }
        }

        // 이 오브젝트 자신을 비활성화
        gameObject.SetActive(false);
    }

    void Start()
    {
        if (objects == null || objects.Length == 0)
        {
            Debug.LogError("Objects array is not set or empty!");
            return;
        }

        // 이 오브젝트가 활성화된 경우에만 코루틴을 시작합니다.
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ChangeVisibilityRoutine());
        }
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

            // 새로운 인덱스를 저장하여 다음 랜덤 생성시 동일한 오브젝트가 선택되지 않도록 함
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
