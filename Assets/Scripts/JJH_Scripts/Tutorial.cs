using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI ScriptTxt;
    int clickCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = "test text 0";    
    }

    // Update is called once per frame
    public void CntUp()
    {
        Debug.Log(clickCnt);

        clickCnt += 1;
        ScriptTxt.text = "test text " + clickCnt.ToString();
    }
}
