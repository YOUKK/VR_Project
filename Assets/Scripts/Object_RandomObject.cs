using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class Object_RandomObject : MonoBehaviour
{
    [SerializeField]
    private Button randomButton;
    [SerializeField]
    private GameObject[] lowPlateLowPlates = new GameObject[20];
    [SerializeField]
    private int countdownTime = 5;
    [SerializeField]
    private TextMeshProUGUI countdownDisplay;



    private bool isCountingDown = false;

    void Start()
    {
        foreach (GameObject plate in lowPlateLowPlates)
        {
            plate.SetActive(false);
        }

        randomButton.onClick.AddListener(() =>
        {
            foreach (GameObject plate in lowPlateLowPlates)
            {
                plate.SetActive(false);
            }

            ActivateRandomPlates(15);
            randomButton.gameObject.SetActive(false);
            StartCountdown();
        });



    }

    void ActivateRandomPlates(int count)
    {
        List<int> activatedIndexes = new List<int>();

        while (activatedIndexes.Count < count)
        {
            int index = Random.Range(0, lowPlateLowPlates.Length);
            if (!activatedIndexes.Contains(index))
            {
                activatedIndexes.Add(index);
            }
        }

        foreach (int index in activatedIndexes)
        {
            lowPlateLowPlates[index].SetActive(true);
        }
    }

    public void StartCountdown()
    {
        if (!isCountingDown)
        {
            StartCoroutine(CountdownToStart());
        }
    }

    IEnumerator CountdownToStart()
    {
        isCountingDown = true;
        while (countdownTime > 0 && isCountingDown)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        
    }


    private void StopCountdown()
    {
        Debug.Log("StopCountdown called");
        if (isCountingDown)
        {
            isCountingDown = false;
            countdownDisplay.text = "Paused";
            PlayerPrefs.Save();
        }
    }



}


