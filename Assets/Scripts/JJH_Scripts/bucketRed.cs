using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucketRed : MonoBehaviour
{
	public List<int> isAnswer = new List<int>();
    public int missCount = 0;

    [SerializeField]
	private GameObject fxShine;

	[SerializeField]
	private Mission2 mission2;

    private void OnTriggerEnter(Collider other)
	{
		// 정답
		if (other.gameObject.name == "Cow" || other.gameObject.name == "Sheep" || other.gameObject.name == "Duck")
        {
            if (mission2.isBeep == 1)
            {
				missCount++;
                isAnswer.Add(0);
            }
            else
            {
                isAnswer.Add(1);
            }
			StartCoroutine(shine());
			other.gameObject.SetActive(false);
		}
        else if(other.gameObject.name == "Train" || other.gameObject.name == "Car") // 오답
        {
            if (mission2.isBeep == 1)
            {
                missCount++;
            }
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
