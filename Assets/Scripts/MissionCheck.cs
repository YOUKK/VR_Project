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

    public void DishCheckOn()
	{
        dishCheckOff.SetActive(false);
        dishCheckOn.SetActive(true);
	}

    public void KnifeCheckOn()
	{
        knifeCheckOff.SetActive(false);
        knifeCheckOn.SetActive(true);
	}

    public void SFCheckOn()
	{
        sfCheckOff.SetActive(false);
        sfCheckOn.SetActive(true);
	}
}
