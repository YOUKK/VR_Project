using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketBlue : MonoBehaviour
{
	public List<int> isAnswer = new List<int>();

    [SerializeField]
    private GameObject fxShine;

    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Train" || other.gameObject.name == "Car")
		{
			isAnswer.Add(1);
            StartCoroutine(shine());
            other.gameObject.SetActive(false);
		}
        else if(other.gameObject.name == "Cow" || other.gameObject.name == "Sheep" || other.gameObject.name == "Duck")
        {
			isAnswer.Add(0);
			other.gameObject.SetActive(false);
		}
		Debug.Log("isAnswer: " + string.Join(", ", isAnswer));
	}

    IEnumerator shine()
    {
        fxShine.SetActive(true);

        yield return new WaitForSeconds(1f);

        fxShine.SetActive(false);
    }
    /*
	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("Car") || other.CompareTag("Animal"))
		{
			other.gameObject.SetActive(false);
		}
	}*/
}
