using UnityEngine;

public class MultiDisplaySetup : MonoBehaviour
{
    public Camera mainCamera;
    public Camera devCamera;

    void Start()
    {
        // Display 2 Ȱ��ȭ
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }

        // Main Camera�� Display 1�� �Ҵ�
        if (mainCamera != null)
        {
            mainCamera.targetDisplay = 0; // Display 1 (VR ����)
        }

        // DEV Camera�� Display 2�� �Ҵ�
        if (devCamera != null)
        {
            devCamera.targetDisplay = 1; // Display 2 (�����)
        }
    }
}
