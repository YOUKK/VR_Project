using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public enum HandType
{
    Right,
    Left
}

// Controller에서 Grip 버튼 입력을 받으면 애니메이션을 실행하는 스크립트
public class ControllerInput : MonoBehaviour
{
    // Action-based
    [SerializeField]
    private InputActionReference GripRef;
    [SerializeField]
    private InputActionAsset actionAsset;

    private Animator animator;

    [SerializeField]
    private bool isGrab;
    private HandType handType;

    private void OnEnable()
    {
        GripRef.action.performed += Grip;
        GripRef.action.canceled += CancelGrip;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
		if (transform.parent.name == "Left Controller")
			handType = HandType.Left;
		else
			handType = HandType.Right;
	}

    private void OnDisable()
    {
        GripRef.action.performed -= Grip;
        GripRef.action.canceled -= CancelGrip;
    }

    private void Grip(InputAction.CallbackContext obj)
    {
        Manager.IsGrabSet(handType, true);
        isGrab = true;
        animator.SetBool("IsGrab", true);
    }

    private void CancelGrip(InputAction.CallbackContext obj)
    {
        Manager.IsGrabSet(handType, false);
        isGrab = false;
        animator.SetBool("IsGrab", false);
    }
}
