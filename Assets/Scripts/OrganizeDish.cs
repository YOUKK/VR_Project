using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeDish : MonoBehaviour
{
    private List<GameObject> dishesSpot = new List<GameObject>(); // 접시가 정리될 위치를 구할 접시들

    public int currentTurn = 0;

    [SerializeField]
    private MissionCheck missionCheck;

    void Start()
    {
        for (int i = 0; i < 21; i++)
        {
            dishesSpot.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {

    }

    private void Organize(Collider other)
    {
        other.transform.parent = dishesSpot[currentTurn].transform;
        other.transform.localPosition = Vector3.zero;
        other.transform.localEulerAngles = Vector3.zero;

        if (currentTurn < 5) currentTurn++;

        other.GetComponent<BoxCollider>().enabled = false;

        Debug.Log($"Organize - {other.gameObject.name} 위치 변경됨, 새로운 부모: {dishesSpot[currentTurn - 1].name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plate") && !Manager.IsGrabGet())
        {
            if (currentTurn < 21)
                Organize(other);
            else
            {
                //currentTurn++;
                other.gameObject.SetActive(false);
            }

            if (currentTurn >= 5)
                missionCheck.DishCheckOn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate") && !Manager.IsGrabGet())
        {
            if (currentTurn < 21)
                Organize(other);
            else
            {
                currentTurn++;
                other.gameObject.SetActive(false);
            }

            if (currentTurn >= 5)
                missionCheck.DishCheckOn();
        }
    }
}
