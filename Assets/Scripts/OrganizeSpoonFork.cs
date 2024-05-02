using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeSpoonFork : MonoBehaviour
{
    private List<GameObject> SFSpot = new List<GameObject>(); // Spoon Fork

    private int currentTurn = 0;

    void Start()
    {
        for (int i = 0; i < 11; i++)
        {
            SFSpot.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        
    }


	private void OnTriggerEnter(Collider other)
	{
		if ((other.CompareTag("Spoon") || other.CompareTag("Fork")) && !Manager.IsGrabGet())
		{
			other.transform.parent = SFSpot[currentTurn].transform;
			currentTurn++;
			other.transform.localPosition = Vector3.zero;
			other.transform.localEulerAngles = Vector3.zero;

			other.GetComponent<BoxCollider>().enabled = false;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if ((other.CompareTag("Spoon") || other.CompareTag("Fork")) && !Manager.IsGrabGet())
		{
			other.transform.parent = SFSpot[currentTurn].transform;
			currentTurn++;
			other.transform.localPosition = Vector3.zero;
			other.transform.localEulerAngles = Vector3.zero;

			other.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
