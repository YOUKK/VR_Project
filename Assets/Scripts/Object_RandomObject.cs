using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class Object_RandomObject : MonoBehaviour
{
    [SerializeField]
    private Button randomButton; //        ġ   ư
    [SerializeField]
    private GameObject[] lowPlateLowPlates = new GameObject[20]; //  ׸  GameObject 20      迭       
    [SerializeField]
    private int countdownTime = 5; // ī  Ʈ ٿ   ð   ʱⰪ     
    [SerializeField]
    private TextMeshProUGUI countdownDisplay; // ī  Ʈ ٿ    ǥ     TextMeshProUGUI       Ʈ
    [SerializeField]
    private Button resultButton; //            ư
    [SerializeField]
    private Button homeButton; //     ȭ          ư      ư
    [SerializeField]
    private Button stopButton; //        ư
    [SerializeField]
    private TextMeshProUGUI stoptimeDisplay; //       ð    ǥ     TextMeshProUGUI       Ʈ

    private bool isCountingDown = false; // ī  Ʈ ٿ                 θ      

    void Start()
    {
        foreach (GameObject plate in lowPlateLowPlates)
        {
            plate.SetActive(false); //             GameObject   Ȱ  ȭ
            resultButton.gameObject.SetActive(false); //       ư   Ȱ  ȭ
        }

        randomButton.onClick.AddListener(() =>
        {
            foreach (GameObject plate in lowPlateLowPlates)
            {
                plate.SetActive(false); //   ư Ŭ       ٽ      GameObject     Ȱ  ȭ
            }

            ActivateRandomPlates(15); //          15     GameObject Ȱ  ȭ
            randomButton.gameObject.SetActive(false); // randomButton   ư   Ȱ  ȭ
            StartCountdown(); // ī  Ʈ ٿ      
        });

        resultButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scenario1_Result"); //            ư Ŭ           ȯ
        });

        homeButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Scene_YYJ"); // Ȩ   ư Ŭ           ȯ
        });

        stopButton.onClick.AddListener(StopCountdown); //        ư         ߰ 


    }

    void ActivateRandomPlates(int count)
    {
        List<int> activatedIndexes = new List<int>();

        while (activatedIndexes.Count < count)
        {
            int index = Random.Range(0, lowPlateLowPlates.Length);
            if (!activatedIndexes.Contains(index))
            {
                activatedIndexes.Add(index); // Ȱ  ȭ   GameObject         ε        
            }
        }

        foreach (int index in activatedIndexes)
        {
            lowPlateLowPlates[index].SetActive(true);  //    õ   ε      GameObject Ȱ  ȭ
        }
    }

    public void StartCountdown()
    {
        if (!isCountingDown) //      ī  Ʈ ٿ                ʴٸ      
        {
            StartCoroutine(CountdownToStart());
        }
    }

    IEnumerator CountdownToStart()
    {
        isCountingDown = true;
        while (countdownTime > 0 && isCountingDown) // isCountingDown       ߰ 
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        if (isCountingDown) //            ī  Ʈ ٿ     Ϸ Ǿ       
        {
            resultButton.gameObject.SetActive(true); //       ư Ȱ  ȭ
        }
        else // ī  Ʈ ٿ         Ǿ       
        {
            stoptimeDisplay.text = countdownTime.ToString(); //         ð  ǥ  
        }

        countdownDisplay.text = ""; // ī  Ʈ ٿ   ؽ Ʈ  ʱ ȭ
        if (countdownTime <= 0) // ī  Ʈ ٿ    0              
        {
            stoptimeDisplay.text = "0"; // stoptimeDisplay   0 ǥ  
            PlayerPrefs.SetString("StopTimeText", "0"); //          
            PlayerPrefs.Save(); //                      
        }
        isCountingDown = false; // ī  Ʈ ٿ     ¸  false       
    }


    private void StopCountdown()
    {
        Debug.Log("StopCountdown called"); //  α׸   ߰  Ͽ   ޼    ȣ   Ȯ  
        if (isCountingDown)
        {
            isCountingDown = false; // ī  Ʈ ٿ      
            stoptimeDisplay.text = countdownTime.ToString(); //            ð    stoptimeDisplay   ǥ  
            countdownDisplay.text = "Paused"; // ī  Ʈ ٿ              ˸     ؽ Ʈ
            resultButton.gameObject.SetActive(true); //    ߱⸦                   ư Ȱ  ȭ
            stopButton.gameObject.SetActive(false); //    ߱    ư     Ȱ  ȭ
            PlayerPrefs.SetString("StopTimeText", stoptimeDisplay.text); //          
            PlayerPrefs.Save(); //                      
        }
    }



}


