using System.Collections.Generic;
using UnityEngine;

public class OrganizeKnife : MonoBehaviour
{
	private List<GameObject> knifesSpot = new List<GameObject>();

    public int currentTurn = 0;

	[SerializeField]
	private MissionCheck missionCheck;

	void Start()
	{
		for (int i = 0; i < 5; i++)
		{
			knifesSpot.Add(gameObject.transform.GetChild(i).gameObject);
		}
	}

	void Update()
	{

	}

	private void Organize(Collider other)
	{
		other.transform.parent = knifesSpot[currentTurn].transform;
		currentTurn++;
		other.transform.localPosition = Vector3.zero;
		other.transform.localEulerAngles = Vector3.zero;

		other.GetComponent<BoxCollider>().enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Knife") && !Manager.IsGrabGet())
		{
			if (currentTurn < 5)
				Organize(other);
			else
			{
				//currentTurn++;
				other.gameObject.SetActive(false);
			}

			if(currentTurn >= 5)
			{
				missionCheck.KnifeCheckOn();
			}
		}

	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Knife") && !Manager.IsGrabGet())
		{
			if (currentTurn < 5)
				Organize(other);
			else
			{
				//currentTurn++;
				other.gameObject.SetActive(false);
			}

			if (currentTurn >= 5)
			{
				missionCheck.KnifeCheckOn();
			}
		}	
	}
}
