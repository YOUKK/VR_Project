using System.Collections;
using UnityEngine;

public class RandomVisibilityChanger : MonoBehaviour
{
    public GameObject[] objects; // ���� ������ �� ���� ������Ʈ�� �Ҵ�
    private int lastIndex = -1; // ���������� ���� ����� ������Ʈ�� �ε���

    void Start()
    {
        if (objects == null || objects.Length == 0)
        {
            Debug.LogError("Objects array is not set or empty!");
            return;
        }

        // ó������ ��� ������Ʈ�� ����ϴ�.
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }

        // �� ������ �ݺ������� ȣ��
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

            // ���������� ������ ������Ʈ�� ����ϴ�.
            if (lastIndex != -1)
            {
                objects[lastIndex].SetActive(false);
            }

            // ���ο� ������Ʈ�� ���̵��� ����
            objects[newIndex].SetActive(true);

            // ���ο� �ε����� �����Ͽ� ���� �� ���� �� ������ ������Ʈ�� ���õ��� �ʵ��� ��
            lastIndex = newIndex;

            // 3�� ���� ���
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
