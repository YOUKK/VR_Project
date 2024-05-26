using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using TMPro;

public class TotalResult : MonoBehaviour
{
    static public int mission1Quiz = 0;
    static public int mission2Quiz = 0;
    static public int mission1Clear = 0; //미션 완수한 미션 수
    static public int mission1CorrectItem = 0; //올바르게 옮긴 물건 수 
    static public int mission2CorrectItem = 0; //올바르게 옮긴 물건 수

    static public int clickNum = 0;

    private double mission1Point = 40 / 20;
    private double mission2Point = 40 / 15;

    [SerializeField]
    private TextMeshProUGUI missionUnderstand;
    [SerializeField]
    private TextMeshProUGUI mission1;
    [SerializeField]
    private TextMeshProUGUI mission2;
    [SerializeField]
    private TextMeshProUGUI grade;



    void Start()
    {
        Debug.Log("미션1 퀴즈 점수 " + mission1Quiz);
        Debug.Log("미션2 퀴즈 점수 " + mission2Quiz);
        Debug.Log("미션1 완수한 미션 수 " + mission1Clear);
        Debug.Log("미션1 올바르게 옮긴 물건 수 " + mission1CorrectItem);
        Debug.Log("미션2 올바르게 옮긴 물건 수 " + mission2CorrectItem);

        missionUnderstand.text = ((int)((3.0f/clickNum) * 100)).ToString() + "%";
        if (mission1Clear == 3) mission1.text = "100%"; // 미션1의 3개 미션을 모두 완수하면
        else mission1.text = ((int)((mission1CorrectItem/20.0f) * 100)).ToString() + "%";
        if (mission2CorrectItem == 15) mission2.text = "100%";
        else mission2.text = ((int)((mission2CorrectItem/15.0f) * 100)).ToString() + "%";


        //Debug.Log("미션2 " + mission2CorrectItem * mission2Point);
    }


}
