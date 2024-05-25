using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionCheck : MonoBehaviour
{
    [SerializeField] private GameObject dishCheckOn;
    [SerializeField] private GameObject dishCheckOff;
    [SerializeField] private GameObject knifeCheckOn;
    [SerializeField] private GameObject knifeCheckOff;
    [SerializeField] private GameObject sfCheckOn;
    [SerializeField] private GameObject sfCheckOff;



    void Start()
    {

    }

    void Update()
    {
        
    }

    // 접시 미션 완료
    public void DishCheckOn()
	{
        dishCheckOff.SetActive(false);
        dishCheckOn.SetActive(true);

        TotalResult.mission1Clear++;
	}

    // 나이프 미션 완료
    public void KnifeCheckOn()
	{
        knifeCheckOff.SetActive(false);
        knifeCheckOn.SetActive(true);

        TotalResult.mission1Clear++;
    }

    // 스푼 포크 미션 완료
    public void SFCheckOn()
	{
        sfCheckOff.SetActive(false);
        sfCheckOn.SetActive(true);

        TotalResult.mission1Clear++;
    }
}
