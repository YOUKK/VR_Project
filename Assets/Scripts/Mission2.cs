using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2 : MonoBehaviour
{
    [SerializeField]
    private GameObject toyCars;
    [SerializeField]
    private GameObject toyCows;
    [SerializeField]
    private GameObject toyDucks;
    [SerializeField]
    private GameObject toySheep;
    [SerializeField]
    private GameObject toyTrains;

    private GameObject[] allToys;
    private List<string> toyTypes = new List<string>(); // �峭�� ���� ���� ����Ʈ: doll, ndoll
    private List<int> toySoundIndices = new List<int>(); // �峭�� �Ҹ� ���� ���� ����Ʈ: 1(������), 0(�峭�� �Ҹ�)

    private void Start()
    {
        allToys = new GameObject[] { toyCars, toyCows, toyDucks, toySheep, toyTrains };
    }

    public IEnumerator ActivateToysRandomly()
    {
        HashSet<GameObject> chosenToys = new HashSet<GameObject>();
        while (chosenToys.Count < 10)
        {
            
            GameObject selectedToy = allToys[Random.Range(0, allToys.Length)];

            if (chosenToys.Add(selectedToy))
            {
                selectedToy.SetActive(true);

                ToyAudio toyAudio = selectedToy.GetComponent<ToyAudio>();// ToyAudio ������Ʈ ��������
                if (toyAudio != null)
                {
                    toyAudio.PlayRandomToySound();// �峭�� �Ҹ� or ������ �� �������� �Ҹ� ���
                    toySoundIndices.Add(toyAudio.CurrentSoundIndex);// �Ҹ� ���� ����Ʈ�� ����
                }

                // �峭�� ���� ����
                if (toyCars == selectedToy || toyTrains == selectedToy)
                {
                    toyTypes.Add("ndoll");
                }
                else
                {
                    toyTypes.Add("doll");
                }
                Debug.Log("�峭�� ���� ���: " + string.Join(", ", toyTypes));
                Debug.Log("�峭�� �Ҹ� ����: " + string.Join(", ", toySoundIndices));

                yield return new WaitForSeconds(4f);//4��
                selectedToy.SetActive(false);
            }
        }

        /*Debug.Log("�峭�� ���� ���: " + string.Join(", ", toyTypes));
        Debug.Log("�峭�� �Ҹ� ����: " + string.Join(", ", toySoundIndices));*/
    }

    private bool ArrayContains(GameObject[] array, GameObject item)
    {
        foreach (GameObject obj in array)
        {
            if (obj == item)
            {
                return true;
            }
        }
        return false;
    }
}
