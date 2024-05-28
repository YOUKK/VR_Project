using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganizeDish : MonoBehaviour
{
    private List<GameObject> dishesSpot = new List<GameObject>(); // 접시가 정리될 위치를 구할 접시들

    public int currentTurn = 0; // 현재 정리한 개수, 최대 5까지 카운트
    public int index = 0; // dishesSpot의 인덱스로 쓸 값

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
        other.transform.parent = dishesSpot[index].transform;
        other.transform.localPosition = Vector3.zero;
        other.transform.localEulerAngles = Vector3.zero;

        index++;
        if (currentTurn < 5) currentTurn++;

        other.GetComponent<BoxCollider>().enabled = false;

        Debug.Log($"Organize - {other.gameObject.name} 위치 변경됨, 새로운 부모: {dishesSpot[index - 1].name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plate") && !Manager.IsGrabGet())
        {
            if (index < 21)
                Organize(other);
            else
            {
                //currentTurn++;
                other.gameObject.SetActive(false);
            }

            if (index >= 5)
                missionCheck.DishCheckOn();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Plate") && !Manager.IsGrabGet())
        {
            if (index < 21)
                Organize(other);
            else
            {
                //currentTurn++;
                other.gameObject.SetActive(false);
            }

            if (index >= 5)
                missionCheck.DishCheckOn();
        }
    }
}
