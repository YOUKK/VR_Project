using System.IO;
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
        private static string desktopPath = @"C:\Users\emsys\Desktop";

        private static string csvFilePath = Path.Combine(desktopPath, "test.csv");
        private static bool fileHeaderWritten = false;

        private void AppendToCSV(float gazeTransitionTime, float gazeDuration)
        {
            if (!File.Exists(csvFilePath) || !fileHeaderWritten)
            {
                File.WriteAllText(csvFilePath, "gazeTransitionTime,gazeDuration\n");
                fileHeaderWritten = true;
            }

            using (StreamWriter sw = File.AppendText(csvFilePath))
            {
                sw.WriteLine($"{gazeTransitionTime},{gazeDuration}");
            }
        }

        public void GazeFocusChanged(bool hasFocus)
        {
            if (hasFocus)
            {
                Debug.Log($"포커스 됨: {gameObject.name} 저장");
                gazeEnterTime = Time.time;
                lastGazedObject = gameObject;
                _targetColor = highlightColor;
            }
            else
            {
                Debug.Log($"포커스 사라짐: {gameObject.name} 저장");
                float gazeDuration = Time.time - gazeEnterTime;
                float gazeTransitionTime = 0f;
                if (lastGazedObject != null && lastGazedObject != this.gameObject)
                {
                    gazeTransitionTime = gazeEnterTime - lastGazeLeaveTime;
                }

                AppendToCSV(gazeTransitionTime, gazeDuration);

                lastGazeLeaveTime = Time.time;
                lastGazedObject = null;
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
