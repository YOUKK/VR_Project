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
    public int isBeep = 0;

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
        // �̼� ���� �ؽ�Ʈ�� �������� 1�� �� �̼� ����
        yield return new WaitForSeconds(1f);

        int count = 0;
        while (count < 15)
        {

            GameObject selectedToy = allToys[Random.Range(0, allToys.Length)];

            if(selectedToy == toyCars)
            {
                selectedToy.transform.position = new Vector3(3.334347f, 1.718282f, -1.759459f);
                selectedToy.transform.rotation = Quaternion.Euler(new Vector3(-180, 0, 0));
            }else if(selectedToy == toyCows)
            {
                selectedToy.transform.position = new Vector3(3.303551f, 1.854282f, -1.689112f);
                selectedToy.transform.rotation = Quaternion.Euler(new Vector3(90, 180, 199.287f));
            }else if(selectedToy == toyDucks)
            {
                selectedToy.transform.position = new Vector3(3.29226f, 1.815282f, -1.784569f);
                selectedToy.transform.rotation = Quaternion.Euler(new Vector3(90, 180, -58.573f));
            }else if (selectedToy == toyTrains)
            {
                selectedToy.transform.position = new Vector3(3.334347f, 1.758282f, -1.79446f);
                selectedToy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            }
            else if (selectedToy == toySheep)
            {
                selectedToy.transform.position = new Vector3(3.270312f, 1.884282f, -1.77649f);
                selectedToy.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 117.789f));
            }

            selectedToy.SetActive(true);

            ToyAudio toyAudio = selectedToy.GetComponent<ToyAudio>();// ToyAudio ������Ʈ ��������
            if (toyAudio != null)
            {
                toyAudio.PlayRandomToySound();// �峭�� �Ҹ� or ������ �� �������� �Ҹ� ���
                isBeep = toyAudio.CurrentSoundIndex;
                toySoundIndices.Add(isBeep);// �Ҹ� ���� ����Ʈ�� ����
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
                int sum3 = toySoundIndices.Sum();

                int total = sum1 + sum2 + sum3 - bucketBlue.missCount - bucketRed.missCount;
                TotalResult.mission2CorrectItem = total;

                if (total == 15)
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

        yield break; // �ڷ�ƾ ����
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
