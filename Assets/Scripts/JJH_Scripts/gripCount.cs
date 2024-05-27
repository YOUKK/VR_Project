using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class gripCount : MonoBehaviour
{
    [SerializeField] private InputActionReference leftSelectRef;
    [SerializeField] private InputActionReference leftActivateRef;
    [SerializeField] private InputActionReference rightSelectRef;
    [SerializeField] private InputActionReference rightActivateRef;
    [SerializeField] private InputActionAsset actionAsset;

    [SerializeField]
    private TotalResult TotalResult;

    private void OnEnable()
    {
        actionAsset.Enable();

        leftSelectRef.action.performed += SelectLeft;
        leftActivateRef.action.performed += ActivateLeft;
        rightSelectRef.action.performed += SelectRight;
        rightActivateRef.action.performed += ActivateRight;
    }

    private void OnDisable()
    {
        actionAsset.Disable();
        leftSelectRef.action.performed -= SelectLeft;
        leftActivateRef.action.performed -= ActivateLeft;
        rightSelectRef.action.performed -= SelectRight;
        rightActivateRef.action.performed -= ActivateRight;
    }

    private void SelectLeft(InputAction.CallbackContext obj)
    {
        TotalResult.buttonClickNum++;
        Debug.Log("ClickCount: " + TotalResult.buttonClickNum);
    }
    private void ActivateLeft(InputAction.CallbackContext obj)
    {
        TotalResult.buttonClickNum++;
        Debug.Log("ClickCount: " + TotalResult.buttonClickNum);
    }
    private void SelectRight(InputAction.CallbackContext obj)
    {
        TotalResult.buttonClickNum++;
        Debug.Log("ClickCount: " + TotalResult.buttonClickNum);
    }
    private void ActivateRight(InputAction.CallbackContext obj)
    {
        TotalResult.buttonClickNum++;
        Debug.Log("ClickCount: " + TotalResult.buttonClickNum);
    }
}
