using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class gripCount : MonoBehaviour
{
    //[SerializeField] public XRController leftController = null;
    [SerializeField] private InputActionReference leftSelectRef;
    [SerializeField] private InputActionReference leftActivateRef;
    [SerializeField] private InputActionReference rightSelectRef;
    [SerializeField] private InputActionReference rightActivateRef;
    [SerializeField] private InputActionAsset actionAsset;
    private int countClick = 0;

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
        countClick++;
        Debug.Log("ClcickCount: " + countClick);
    }
    private void ActivateLeft(InputAction.CallbackContext obj)
    {
        countClick++;
        Debug.Log("ClcickCount: " + countClick);
    }
    private void SelectRight(InputAction.CallbackContext obj)
    {
        countClick++;
        Debug.Log("ClcickCount: " + countClick);
    }
    private void ActivateRight(InputAction.CallbackContext obj)
    {
        countClick++;
        Debug.Log("ClcickCount: " + countClick);
    }
}
