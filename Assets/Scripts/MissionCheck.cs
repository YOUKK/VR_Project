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

    // ���� �̼� �Ϸ�
    public void DishCheckOn()
	{
        dishCheckOff.SetActive(false);
        dishCheckOn.SetActive(true);

        TotalResult.mission1Clear++;
	}

    // ������ �̼� �Ϸ�
    public void KnifeCheckOn()
	{
        knifeCheckOff.SetActive(false);
        knifeCheckOn.SetActive(true);

        TotalResult.mission1Clear++;
    }

    // ��Ǭ ��ũ �̼� �Ϸ�
    public void SFCheckOn()
	{
        sfCheckOff.SetActive(false);
        sfCheckOn.SetActive(true);

        TotalResult.mission1Clear++;
    }
}
