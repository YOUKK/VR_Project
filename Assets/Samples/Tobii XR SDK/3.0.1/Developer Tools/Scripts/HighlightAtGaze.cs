using Tobii.G2OM;
using UnityEngine;

namespace Tobii.XR.Examples.DevTools
{
    public class HighlightAtGaze : MonoBehaviour, IGazeFocusable
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
                if (lastGazedObject != null && lastGazedObject != gameObject)
                {
                    float gazeTransitionTime = gazeEnterTime - lastGazeLeaveTime;
                    Debug.Log($"Gaze moved from {lastGazedObject.name} to {gameObject.name} in {gazeTransitionTime} seconds.");
                }
                lastGazedObject = gameObject;
                _targetColor = highlightColor;
            }
            else
            {
                lastGazeLeaveTime = Time.time;
                float gazeDuration = lastGazeLeaveTime - gazeEnterTime;
                Debug.Log($"{gameObject.name} was gazed at for {gazeDuration} seconds.");
                _targetColor = _originalColor;
            }
        }

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.material.color;
            _targetColor = _originalColor;
        }

        private void Update()
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
}
