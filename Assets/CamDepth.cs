using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamDepth : MonoBehaviour
{
    Camera cam;
    public int depth;

    void Start()
    {
        cam = GetComponent<Camera>();
        cam.depth = depth;
    }
}