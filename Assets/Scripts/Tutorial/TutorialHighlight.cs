using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Tobii.G2OM;

public class TutorialHighlight : MonoBehaviour, IGazeFocusable
{
    private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
    public Color highlightColor = Color.red;
    public float animationTime = 0.1f;

    private Renderer _renderer;
    private Color _originalColor;
    private Color _targetColor;
    private static float lastGazeLeaveTime;
    private static GameObject lastGazedObject;
    private float gazeEnterTime;
    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus)
        {
            gazeEnterTime = Time.time;
            lastGazedObject = gameObject;
            _targetColor = highlightColor;
        }
        else
        {
            float gazeDuration = Time.time - gazeEnterTime;
            float gazeTransitionTime = 0f;
            if (lastGazedObject != null && lastGazedObject != this.gameObject)
            {
                // 시선 전환 시간을 계산합니다.
                gazeTransitionTime = gazeEnterTime - lastGazeLeaveTime;
            }

            // 시선 지속 시간과 시선 전환 시간을 CSV 파일에 기록합니다.
            AppendToCSV(gazeTransitionTime, gazeDuration);

            lastGazeLeaveTime = Time.time;
            lastGazedObject = null;
            _targetColor = _originalColor;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        _targetColor = _originalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (_renderer.material.HasProperty(_baseColor))
        {
            _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime / animationTime));
        }
        else
        {
            _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime / animationTime);
        }
    }
}
