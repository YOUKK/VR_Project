using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrganizeCube : MonoBehaviour
{
    [SerializeField]
    private GameObject Spot;
	[SerializeField]
	private GameObject SuccessText;
	[SerializeField]
	private GameObject bird;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

	IEnumerator Delay()
	{
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene("Eyetracking_Tutorial");
	}

	private void Success()
	{
		SuccessText.SetActive(true);
		bird.SetActive(true);

		// 3초 후 아이트래킹 튜토리얼 씬으로 전환
		StartCoroutine(Delay());
	}

	private void Organize(Collider other)
	{
		other.transform.parent = Spot.transform;
		other.transform.localPosition = Vector3.zero;
		other.transform.localEulerAngles = Vector3.zero;

		other.GetComponent<BoxCollider>().enabled = false;

		Success();
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
