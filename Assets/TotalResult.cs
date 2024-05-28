using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class TotalResult : MonoBehaviour
{
    static public int mission1Quiz = 0;
    static public int mission2Quiz = 0;
    static public int mission1Clear = 0; // �̼� �ϼ��� �̼� ��
    static public int mission1CorrectItem = 0; // �ùٸ��� �ű� ���� �� 
    static public int mission2CorrectItem = 0; // �ùٸ��� �ű� ���� ��
    static public int clickNum = 0;
    static public int buttonClickNum = 0;

    private double mission1Point = 40 / 20.0;
    private double mission2Point = 40 / 15.0;

    private double missionQuizP = 0; // �̼�1, 2 ���� ��Ȯ�� %
    private double mission1P = 0; // �̼�1 ���൵ %
    private double mission2P = 0; // �̼�2 ���൵ %

    [SerializeField]
    private TextMeshProUGUI missionUnderstand;
    [SerializeField]
    private TextMeshProUGUI mission1;
    [SerializeField]
    private TextMeshProUGUI mission2;
    [SerializeField]
    private GameObject pass;
    [SerializeField]
    private GameObject unPass;

    private string csvFilePath = Path.Combine(@"C:\Users\emsys\Desktop", "test.csv");

    void Start()
    {
        Debug.Log("�̼�1 ���� ���� " + mission1Quiz);
        Debug.Log("�̼�2 ���� ���� " + mission2Quiz);
        Debug.Log("�̼�1 �ϼ��� �̼� �� " + mission1Clear);
        Debug.Log("�̼�1 �ùٸ��� �ű� ���� �� " + mission1CorrectItem);
        Debug.Log("�̼�2 �ùٸ��� �ű� ���� �� " + mission2CorrectItem);

        missionQuizP = (3.0f / clickNum) * 100; // �̼�1, 2 ���� ��Ȯ�� %
        mission1P = (mission1CorrectItem / 20.0f) * 100; // �̼�1 ���൵ % 
        mission2P = (mission2CorrectItem / 15.0f) * 100; // �̼�2 ���൵ % 

        // �̼� ���ص� �ؽ�Ʈ
        missionUnderstand.text = ((int)(missionQuizP)).ToString() + "%";
        // �̼�1 ���൵ �ؽ�Ʈ
        if (mission1Clear == 3)
            mission1.text = "100%"; // �̼�1�� 3�� �̼��� ��� �ϼ��ϸ�
        else
            mission1.text = ((int)(mission1P)).ToString() + "%";
        // �̼�2 ���൵ �ؽ�Ʈ
        if (mission2CorrectItem == 15)
            mission2.text = "100%";
        else
            mission2.text = ((int)(mission2P)).ToString() + "%";
       
        // ���� ��� ���
        double weightedAverage = CalculateWeightedAverage(missionQuizP, mission1P, mission2P);
        Debug.Log("���/�ǽ��� �Ǵ��ϴ� ���� �ۼ�Ʈ : " +  weightedAverage); 

        // ���� ��
        double threshold = 79.7 * (1 - 0.0644);

        // ����� ���� ������Ʈ Ȱ��ȭ
        if (weightedAverage < threshold)
        {
            unPass.SetActive(true);
            pass.SetActive(false);
        }
        else
        {
            pass.SetActive(true);
            unPass.SetActive(false);
        }
        SaveResultsToCSV();
    }

    private void SaveResultsToCSV()
    {
        if (!File.Exists(csvFilePath))
        {
            File.WriteAllText(csvFilePath, "mission1Quiz,mission2Quiz,mission1Clear,mission1CorrectItem,mission2CorrectItem,clickNum,buttonClickNum\n");
        }

        List<string> lines = new List<string>(File.ReadAllLines(csvFilePath));
        string newLine = $",,,,,,{buttonClickNum}";

        using (StreamWriter sw = new StreamWriter(csvFilePath))
        {
            foreach (string line in lines)
            {
                sw.WriteLine(line);
            }
            sw.WriteLine(newLine);
        }
    }
    private double CalculateWeightedAverage(double missionQuizP, double mission1P, double mission2P)
    {
        // ����ġ ����
        double weight1 = 1.0;
        double weight2 = 2.0;
        double weight3 = 2.0;

        // ���� ��� ���
        double weightedSum = (missionQuizP * weight1) + (mission1P * weight2) + (mission2P * weight3);
        double weightSum = weight1 + weight2 + weight3;

        return weightedSum / weightSum;
    }
}
