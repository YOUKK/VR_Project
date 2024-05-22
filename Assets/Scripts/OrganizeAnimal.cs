using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeAnimal : MonoBehaviour
{
	private List<GameObject> animalSpot = new List<GameObject>();

	public int currentTurn = 0;

	[SerializeField]
	private MissionCheck missionCheck;

	void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			animalSpot.Add(gameObject.transform.GetChild(i).gameObject);
		}
	}

	void Update()
	{

	}

	private void Organize(Collider other)
	{
		other.transform.parent = animalSpot[currentTurn].transform;
		currentTurn++;
		other.transform.localPosition = Vector3.zero;
		other.transform.localEulerAngles = Vector3.zero;

		other.GetComponent<BoxCollider>().enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Animal") && !Manager.IsGrabGet())
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
		if (other.CompareTag("Animal") && !Manager.IsGrabGet())
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
