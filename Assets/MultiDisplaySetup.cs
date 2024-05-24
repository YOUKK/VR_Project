using UnityEngine;

public class MultiDisplaySetup : MonoBehaviour
{
    public Camera mainCamera;
    public Camera devCamera;

    void Start()
    {
        // Display 2 활성화
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }

        // Main Camera는 Display 1에 할당
        if (mainCamera != null)
        {
            mainCamera.targetDisplay = 0; // Display 1 (VR 헤드셋)
        }

        // DEV Camera는 Display 2에 할당
        if (devCamera != null)
        {
            devCamera.targetDisplay = 1; // Display 2 (모니터)
        }
    }
}
