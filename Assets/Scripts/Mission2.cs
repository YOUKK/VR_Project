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
    private List<string> toyTypes = new List<string>(); // �峭�� ���� ���� ����Ʈ: doll, ndoll
    private List<int> toySoundIndices = new List<int>(); // �峭�� �Ҹ� ���� ���� ����Ʈ: 1(������), 0(�峭�� �Ҹ�)

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
            Debug.Log("allToys: " + allToys.Length);
            Debug.Log("�峭�� ���� ���: " + string.Join(", ", toyTypes));
            Debug.Log("�峭�� �Ҹ� ����: " + string.Join(", ", toySoundIndices));

            yield return new WaitForSeconds(4f);//4��
            selectedToy.SetActive(false);
            count++;

            // �̼�2 ������ ����
            if (count == 15)
            {
                int sum1 = bucketRed.isAnswer.Sum();
                int sum2 = bucketBlue.isAnswer.Sum();

                if (sum1 + sum2 == 0)
                {
                    ResultSuccess.SetActive(true);
                    Debug.Log("����");
                    //CountBackground.SetActive(false);
                    //CountTxt.gameObject.SetActive(false);
                    //5�ʵ� ����ȯ
                    yield return new WaitForSeconds(5f);
                    SceneManager.LoadScene("Scene_Result");
                }
                else
                {
                    ResultFail.SetActive(true);
                    Debug.Log("����");
                    //CountBackground.SetActive(false);
                    //CountTxt.gameObject.SetActive(false);
                    //5�ʵ� ����ȯ
                    yield return new WaitForSeconds(5f);
                    SceneManager.LoadScene("Scene_Result");
                }
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
