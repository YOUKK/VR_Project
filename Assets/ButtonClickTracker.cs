using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonClickTracker : MonoBehaviour
{
    public ActionBasedController leftController; // LeftHand Controller
    public ActionBasedController rightController; // RightHand Controller

    private int leftClickCount = 0; // Left Controller 클릭 횟수 저장 변수
    private int rightClickCount = 0; // Right Controller 클릭 횟수 저장 변수

    private void OnEnable()
    {
        if (leftController != null && leftController.selectAction.action != null)
        {
            leftController.selectAction.action.performed += OnLeftTriggerPressed;
            leftController.selectAction.action.Enable();
        }

        if (rightController != null && rightController.selectAction.action != null)
        {
            rightController.selectAction.action.performed += OnRightTriggerPressed;
            rightController.selectAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (leftController != null && leftController.selectAction.action != null)
        {
            leftController.selectAction.action.performed -= OnLeftTriggerPressed;
            leftController.selectAction.action.Disable();
        }

        if (rightController != null && rightController.selectAction.action != null)
        {
            rightController.selectAction.action.performed -= OnRightTriggerPressed;
            rightController.selectAction.action.Disable();
        }
    }

    private void OnLeftTriggerPressed(InputAction.CallbackContext context)
    {
        leftClickCount++;
        Debug.Log("Left Trigger clicked " + leftClickCount + " times.");
    }

    private void OnRightTriggerPressed(InputAction.CallbackContext context)
    {
        rightClickCount++;
        Debug.Log("Right Trigger clicked " + rightClickCount + " times.");
    }

    // 클릭 횟수를 리셋하는 메소드 (선택사항)
    public void ResetClickCount()
    {
        leftClickCount = 0;
        rightClickCount = 0;
        Debug.Log("Trigger click counts reset.");
    }
}
