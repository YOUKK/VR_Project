using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeCar : MonoBehaviour
{
	private List<GameObject> dollSpot = new List<GameObject>();

	public int currentTurn = 0;

	[SerializeField]
	private MissionCheck missionCheck;

	void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			dollSpot.Add(gameObject.transform.GetChild(i).gameObject);
		}
	}

	void Update()
	{

	}

	private void Organize(Collider other)
	{
		other.transform.parent = dollSpot[currentTurn].transform;
		currentTurn++;
		other.transform.localPosition = Vector3.zero;
		other.transform.localEulerAngles = Vector3.zero;

		other.GetComponent<BoxCollider>().enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if ((other.CompareTag("Car") || other.CompareTag("Animal")) && !Manager.IsGrabGet())
		{
			if (currentTurn < 3)
				Organize(other);
			else
			{
				currentTurn++;
				other.gameObject.SetActive(false);
			}

			//if (currentTurn >= 10)
			//{
			//	missionCheck.KnifeCheckOn();
			//}
		}

	}

	private void OnTriggerStay(Collider other)
	{
		if ((other.CompareTag("Car") || other.CompareTag("Animal")) && !Manager.IsGrabGet())
		{
			if (currentTurn < 3)
				Organize(other);
			else
			{
				currentTurn++;
				other.gameObject.SetActive(false);
			}

			//if (currentTurn >= 10)
			//{
			//	missionCheck.KnifeCheckOn();
			//}
		}
	}
}
