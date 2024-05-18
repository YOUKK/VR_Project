using System.Collections.Generic;
using UnityEngine;

public class ObRandom : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lowPlateLowPlates = new GameObject[20];
    [SerializeField]
    private GameObject[] knives = new GameObject[10];
    [SerializeField]
    private GameObject[] forks = new GameObject[10];
    [SerializeField]
    private GameObject[] spoons = new GameObject[10];

    void Start()
    {
        ActivateRandomPlates(15);
        ActivateRandomKnives(5);
        ActivateRandomForks(5);
        ActivateRandomSpoons(5);
    }

    void ActivateRandomPlates(int count)
    {
        ActivateRandomObjects(lowPlateLowPlates, count);
    }

    void ActivateRandomKnives(int count)
    {
        ActivateRandomObjects(knives, count);
    }

    void ActivateRandomForks(int count)
    {
        ActivateRandomObjects(forks, count);
    }

    void ActivateRandomSpoons(int count)
    {
        ActivateRandomObjects(spoons, count);
    }

    void ActivateRandomObjects(GameObject[] objectsArray, int count)
    {
        foreach (GameObject obj in objectsArray)
        {
            obj.SetActive(false);
        }

        List<int> activatedIndexes = new List<int>();

        while (activatedIndexes.Count < count)
        {
            int index = Random.Range(0, objectsArray.Length);
            if (!activatedIndexes.Contains(index))
            {
                activatedIndexes.Add(index);
            }
        }

        foreach (int index in activatedIndexes)
        {
            objectsArray[index].SetActive(true);
        }
    }
}
