using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeSpoonFork : MonoBehaviour
{
    private List<GameObject> SFSpot = new List<GameObject>(); // Spoon Fork

	public int index = 0; // SFSpot의 인덱스로 쓸 값
    public int currentTurn = 0; // forkNum + spoonNum
	public int forkNum = 0;
	public int spoonNum = 0;

	[SerializeField]
	private MissionCheck missionCheck;

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

	private void Organize(Collider other)
	{
		other.transform.parent = SFSpot[index].transform;
		other.transform.localPosition = Vector3.zero;
		other.transform.localEulerAngles = Vector3.zero;

        other.GetComponent<BoxCollider>().enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if ((other.CompareTag("Spoon") || other.CompareTag("Fork")) && !Manager.IsGrabGet())
		{
			if (index < 11)
				Organize(other);
			else
			{
				//currentTurn++;
				other.gameObject.SetActive(false);
			}

			// 스푼, 포크 정리 개수 구하기
			if (other.CompareTag("Spoon"))
				spoonNum++;
			else
				forkNum++;

			if (spoonNum >= 5 && forkNum >= 5)
				missionCheck.SFCheckOn();

			int under5Spoon = spoonNum, under5Fork = forkNum;
			if (spoonNum > 5) under5Spoon = 5;
			if (forkNum > 5) under5Fork = 5;

			currentTurn = under5Spoon + under5Fork;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if ((other.CompareTag("Spoon") || other.CompareTag("Fork")) && !Manager.IsGrabGet())
		{
			if (index < 11)
				Organize(other);
			else
			{
				//currentTurn++;
				other.gameObject.SetActive(false);
			}

			// 스푼, 포크 정리 개수 구하기
			if (other.CompareTag("Spoon"))
				spoonNum++;
			else
				forkNum++;

			if (spoonNum >= 5 && forkNum >= 5)
				missionCheck.SFCheckOn();

			int under5Spoon = spoonNum, under5Fork = forkNum;
			if (spoonNum > 5) under5Spoon = 5;
			if (forkNum > 5) under5Fork = 5;

			currentTurn = under5Spoon + under5Fork;
		}
	}
}
