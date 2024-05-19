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
        if (lowPlateLowPlates != null && lowPlateLowPlates.Length > 0)
        {
            ActivateRandomObjects(lowPlateLowPlates, count);
        }
        else
        {
            Debug.LogWarning("lowPlateLowPlates array is not assigned or is empty.");
        }
    }

    void ActivateRandomKnives(int count)
    {
        if (knives != null && knives.Length > 0)
        {
            ActivateRandomObjects(knives, count);
        }
        else
        {
            Debug.LogWarning("knives array is not assigned or is empty.");
        }
    }

    void ActivateRandomForks(int count)
    {
        if (forks != null && forks.Length > 0)
        {
            ActivateRandomObjects(forks, count);
        }
        else
        {
            Debug.LogWarning("forks array is not assigned or is empty.");
        }
    }

    void ActivateRandomSpoons(int count)
    {
        if (spoons != null && spoons.Length > 0)
        {
            ActivateRandomObjects(spoons, count);
        }
        else
        {
            Debug.LogWarning("spoons array is not assigned or is empty.");
        }
    }

    void ActivateRandomObjects(GameObject[] objectsArray, int count)
    {
        if (objectsArray == null || objectsArray.Length == 0)
        {
            Debug.LogError("The objects array is null or empty.");
            return;
        }

        foreach (GameObject obj in objectsArray)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
            else
            {
                Debug.LogWarning("One of the objects in the array is null.");
            }
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
            if (objectsArray[index] != null)
            {
                objectsArray[index].SetActive(true);
            }
        }
    }
}
