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
    private List<string> toyTypes = new List<string>(); // 장난감 종류 저장 리스트: doll, ndoll
    private List<int> toySoundIndices = new List<int>(); // 장난감 소리 종류 저장 리스트: 1(비프음), 0(장난감 소리)

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

                ToyAudio toyAudio = selectedToy.GetComponent<ToyAudio>();// ToyAudio 컴포넌트 가져오기
                if (toyAudio != null)
                {
                    toyAudio.PlayRandomToySound();// 장난감 소리 or 비프음 중 랜덤으로 소리 재생
                    toySoundIndices.Add(toyAudio.CurrentSoundIndex);// 소리 종류 리스트에 저장
                }

                // 장난감 종류 저장
                if (ArrayContains(toyCars, selectedToy) || ArrayContains(toyTrains, selectedToy))
                {
                    toyTypes.Add("ndoll");
                }
                else
                {
                    toyTypes.Add("doll");
                }
                Debug.Log("장난감 종류 결과: " + string.Join(", ", toyTypes));
                Debug.Log("장난감 소리 종류: " + string.Join(", ", toySoundIndices));

                yield return new WaitForSeconds(4f);//4초
                selectedToy.SetActive(false);
            }
        }

        /*Debug.Log("장난감 종류 결과: " + string.Join(", ", toyTypes));
        Debug.Log("장난감 소리 종류: " + string.Join(", ", toySoundIndices));*/
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
