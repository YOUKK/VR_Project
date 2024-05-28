using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class TotalResult : MonoBehaviour
{
    static public int mission1Quiz = 0;
    static public int mission2Quiz = 0;
    static public int mission1Clear = 0; // 미션 완수한 미션 수
    static public int mission1CorrectItem = 0; // 올바르게 옮긴 물건 수 
    static public int mission2CorrectItem = 0; // 올바르게 옮긴 물건 수
    static public int clickNum = 0;
    static public int buttonClickNum = 0;

    private double mission1Point = 40 / 20.0;
    private double mission2Point = 40 / 15.0;

    private double missionQuizP = 0; // 미션1, 2 퀴즈 정확도 %
    private double mission1P = 0; // 미션1 수행도 %
    private double mission2P = 0; // 미션2 수행도 %

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
        Debug.Log("미션1 퀴즈 점수 " + mission1Quiz);
        Debug.Log("미션2 퀴즈 점수 " + mission2Quiz);
        Debug.Log("미션1 완수한 미션 수 " + mission1Clear);
        Debug.Log("미션1 올바르게 옮긴 물건 수 " + mission1CorrectItem);
        Debug.Log("미션2 올바르게 옮긴 물건 수 " + mission2CorrectItem);

        missionQuizP = (3.0f / clickNum) * 100; // 미션1, 2 퀴즈 정확도 %
        mission1P = (mission1CorrectItem / 20.0f) * 100; // 미션1 수행도 % 
        mission2P = (mission2CorrectItem / 15.0f) * 100; // 미션2 수행도 % 

        // 미션 이해도 텍스트
        missionUnderstand.text = ((int)(missionQuizP)).ToString() + "%";
        // 미션1 수행도 텍스트
        if (mission1Clear == 3)
            mission1.text = "100%"; // 미션1의 3개 미션을 모두 완수하면
        else
            mission1.text = ((int)(mission1P)).ToString() + "%";
        // 미션2 수행도 텍스트
        if (mission2CorrectItem == 15)
            mission2.text = "100%";
        else
            mission2.text = ((int)(mission2P)).ToString() + "%";
       
        // 가중 평균 계산
        double weightedAverage = CalculateWeightedAverage(missionQuizP, mission1P, mission2P);
        Debug.Log("평균/의심을 판단하는 최종 퍼센트 : " +  weightedAverage); 

        // 기준 값
        double threshold = 79.7 * (1 - 0.0644);

        // 결과에 따라 오브젝트 활성화
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
        // 가중치 설정
        double weight1 = 1.0;
        double weight2 = 2.0;
        double weight3 = 2.0;

        // 가중 평균 계산
        double weightedSum = (missionQuizP * weight1) + (mission1P * weight2) + (mission2P * weight3);
        double weightSum = weight1 + weight2 + weight3;

        return weightedSum / weightSum;
    }
}
