using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private List<string> toyTypes = new List<string>(); // 장난감 종류 저장 리스트: doll, ndoll
    private List<int> toySoundIndices = new List<int>(); // 장난감 소리 종류 저장 리스트: 1(비프음), 0(장난감 소리)

    [SerializeField]
    private bucketRed bucketRed;
    [SerializeField]
    private bucketBlue bucketBlue;
    [SerializeField]
    private GameObject ResultSuccess;
    [SerializeField]
    private GameObject ResultFail;

    private void Start()
    {
        allToys = new GameObject[] { toyCars, toyCows, toyDucks, toySheep, toyTrains };
    }

    public IEnumerator ActivateToysRandomly()
    {
        int count = 0;
        while (count < 15)
        {

            GameObject selectedToy = allToys[Random.Range(0, allToys.Length)];

            selectedToy.transform.position = new Vector3(3.270312f, 1.884282f, -1.77649f);

            selectedToy.SetActive(true);

            ToyAudio toyAudio = selectedToy.GetComponent<ToyAudio>();// ToyAudio 컴포넌트 가져오기
            if (toyAudio != null)
            {
                toyAudio.PlayRandomToySound();// 장난감 소리 or 비프음 중 랜덤으로 소리 재생
                toySoundIndices.Add(toyAudio.CurrentSoundIndex);// 소리 종류 리스트에 저장
            }

            // 장난감 종류 저장
            if (toyCars == selectedToy || toyTrains == selectedToy)
            {
                toyTypes.Add("ndoll");
            }
            else
            {
                toyTypes.Add("doll");
            }
            Debug.Log("allToys: " + allToys.Length);
            Debug.Log("장난감 종류 결과: " + string.Join(", ", toyTypes));
            Debug.Log("장난감 소리 종류: " + string.Join(", ", toySoundIndices));

            yield return new WaitForSeconds(4f);//4초
            selectedToy.SetActive(false);
            count++;

            // 미션2 끝나는 과정
            if (count == 15)
            {
                int sum1 = bucketRed.isAnswer.Sum();
                int sum2 = bucketBlue.isAnswer.Sum();

                if (sum1 + sum2 == 0)
                {
                    ResultSuccess.SetActive(true);
                    Debug.Log("성공");
                    //CountBackground.SetActive(false);
                    //CountTxt.gameObject.SetActive(false);
                    //5초뒤 씬전환
                    yield return new WaitForSeconds(5f);
                    SceneManager.LoadScene("Scene_Result");
                }
                else
                {
                    ResultFail.SetActive(true);
                    Debug.Log("실패");
                    //CountBackground.SetActive(false);
                    //CountTxt.gameObject.SetActive(false);
                    //5초뒤 씬전환
                    yield return new WaitForSeconds(5f);
                    SceneManager.LoadScene("Scene_Result");
                }
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
