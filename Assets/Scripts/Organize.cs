using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organize : MonoBehaviour
{
    private List<GameObject> dishesSpot = new List<GameObject>(); // 접시가 정리될 위치를 구할 접시들

    private int currentTurn = 0;

    void Start()
    {
        for(int i = 0; i < 21; i++)
		{
            dishesSpot.Add(gameObject.transform.GetChild(i).gameObject);
		}
    }

    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Plate") && !Manager.IsGrabGet())
		{
			other.transform.parent = dishesSpot[currentTurn].transform;
			currentTurn++;
			other.transform.localPosition = Vector3.zero;
			other.transform.localEulerAngles = Vector3.zero;

			other.GetComponent<BoxCollider>().enabled = false;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Plate") && !Manager.IsGrabGet())
		{
			other.transform.parent = dishesSpot[currentTurn].transform;
			currentTurn++;
			other.transform.localPosition = Vector3.zero;
			other.transform.localEulerAngles = Vector3.zero;

			other.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
