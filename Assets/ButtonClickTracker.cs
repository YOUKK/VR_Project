using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonClickTracker : MonoBehaviour
{
    public ActionBasedController leftController; // LeftHand Controller
    public ActionBasedController rightController; // RightHand Controller

    private int leftClickCount = 0; // Left Controller Ŭ�� Ƚ�� ���� ����
    private int rightClickCount = 0; // Right Controller Ŭ�� Ƚ�� ���� ����

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

    // Ŭ�� Ƚ���� �����ϴ� �޼ҵ� (���û���)
    public void ResetClickCount()
    {
        leftClickCount = 0;
        rightClickCount = 0;
        Debug.Log("Trigger click counts reset.");
    }
}
