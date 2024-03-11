using System.Collections;
using System.Collections.Generic;
using Tobii.XR;
using UnityEngine;

public class MyBoo : MonoBehaviour
{
    void Awake()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
