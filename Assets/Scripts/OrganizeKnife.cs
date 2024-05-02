using System.Collections.Generic;
using UnityEngine;

public class OrganizeKnife : MonoBehaviour
{
	private List<GameObject> knifesSpot = new List<GameObject>();

	private int currentTurn = 0;

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

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Knife") && !Manager.IsGrabGet())
		{
			other.transform.parent = knifesSpot[currentTurn].transform;
			currentTurn++;
			other.transform.localPosition = Vector3.zero;
			other.transform.localEulerAngles = Vector3.zero;

			other.GetComponent<BoxCollider>().enabled = false;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Knife") && !Manager.IsGrabGet())
		{
			other.transform.parent = knifesSpot[currentTurn].transform;
			currentTurn++;
			other.transform.localPosition = Vector3.zero;
			other.transform.localEulerAngles = Vector3.zero;

			other.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
