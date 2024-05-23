using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] toyCars = new GameObject[2];
    [SerializeField]
    private GameObject[] toyCows = new GameObject[2];
    [SerializeField]
    private GameObject[] toyDucks = new GameObject[2];
    [SerializeField]
    private GameObject[] toySheep = new GameObject[2];
    [SerializeField]
    private GameObject[] toyTrains = new GameObject[2];

    private GameObject[][] allToys;
    private List<string> toyTypes = new List<string>(); // �峭�� ���� ���� ����Ʈ: doll, ndoll
    private List<int> toySoundIndices = new List<int>(); // �峭�� �Ҹ� ���� ���� ����Ʈ: 1(������), 0(�峭�� �Ҹ�)

    private void Start()
    {
        allToys = new GameObject[][] { toyCars, toyCows, toyDucks, toySheep, toyTrains };
        foreach (GameObject[] toyArray in allToys)
        {
            foreach (GameObject toy in toyArray)
            {
                toy.SetActive(false);
            }
        }
    }

    public IEnumerator ActivateToysRandomly()
    {
        HashSet<GameObject> chosenToys = new HashSet<GameObject>();
        while (chosenToys.Count < 10)
        {
            GameObject[] selectedArray = allToys[Random.Range(0, allToys.Length)];
            GameObject selectedToy = selectedArray[Random.Range(0, selectedArray.Length)];

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
                if (ArrayContains(toyCars, selectedToy) || ArrayContains(toyTrains, selectedToy))
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
