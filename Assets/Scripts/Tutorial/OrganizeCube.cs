using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeCube : MonoBehaviour
{
    [SerializeField]
    private GameObject Spot;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

	private void Organize(Collider other)
	{
		other.transform.parent = Spot.transform;
		other.transform.localPosition = Vector3.zero;
		other.transform.localEulerAngles = Vector3.zero;

		other.GetComponent<BoxCollider>().enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Cube") && !Manager.IsGrabGet())
		{
			Organize(other);
		}

	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Cube") && !Manager.IsGrabGet())
		{
			Organize(other);
		}
	}
}
