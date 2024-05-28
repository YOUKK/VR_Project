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

        public Renderer highlightRenderer; // Highlight 레이어를 가진 오브젝트의 Renderer
        private Color _originalColor;
        private Color _targetColor;
        private bool isHighlighted = false;

        private static float lastGazeLeaveTime = 0; // 초기 값 설정
        private static GameObject lastGazedObject;
        private float gazeEnterTime;
        private static string desktopPath = @"C:\Users\emsys\Desktop";
        private static string csvFilePath = Path.Combine(desktopPath, "test.csv");
        private static bool fileHeaderWritten = false;

        private void AppendToCSV(string objectName, float gazeTransitionTime, float gazeDuration, Vector3 position)
        {
            if (!File.Exists(csvFilePath) || !fileHeaderWritten)
            {
                File.WriteAllText(csvFilePath, "ObjectName,gazeTransitionTime,gazeDuration,X,Y,Z,clickCount\n");
                fileHeaderWritten = true;
            }

            using (StreamWriter sw = File.AppendText(csvFilePath))
            {
                sw.WriteLine($"{objectName},{gazeTransitionTime},{gazeDuration},{position.x},{position.y},{position.z}");
            }
        }

        public void GazeFocusChanged(bool hasFocus)
        {
            Vector3 currentPosition = transform.position;
            string currentObjectName = gameObject.name;

            if (hasFocus)
            {
                float gazeTransitionTime = Time.time - lastGazeLeaveTime;

                if (lastGazedObject != null && lastGazedObject != this.gameObject)
                {
                    // 이전 객체에서 현재 객체로의 전환 시간 계산
                    AppendToCSV(lastGazedObject.name, gazeTransitionTime, 0, lastGazedObject.transform.position);
                }

                Debug.Log($"포커스 됨: {currentObjectName} 저장, 위치: {currentPosition}, 전환 시간: {gazeTransitionTime}");
                gazeEnterTime = Time.time;
                lastGazedObject = gameObject;
                isHighlighted = true;
                _targetColor = highlightColor;
            }
            else
            {
                float gazeDuration = Time.time - gazeEnterTime;
                float gazeTransitionTime = Time.time - lastGazeLeaveTime;

                Debug.Log($"포커스 잃음: {currentObjectName} 저장, 위치: {currentPosition}, 응시 시간: {gazeDuration}, 전환 시간: {gazeTransitionTime}");

                AppendToCSV(currentObjectName, gazeTransitionTime, gazeDuration, currentPosition);

                lastGazeLeaveTime = Time.time;
                lastGazedObject = null;
                isHighlighted = false;
                _targetColor = _originalColor;
            }
        }

        private void Start()
        {
            if (highlightRenderer == null)
            {
                Debug.LogWarning("Highlight Renderer가 설정되지 않았습니다.");
            }
            else
            {
                _originalColor = highlightRenderer.material.color;
                _targetColor = _originalColor;
            }
        }

        private void Update()
        {
            if (highlightRenderer != null)
            {
                if (highlightRenderer.material.HasProperty(_baseColor))
                {
                    Color currentColor = highlightRenderer.material.GetColor(_baseColor);
                    highlightRenderer.material.SetColor(_baseColor, Color.Lerp(currentColor, _targetColor, Time.deltaTime * (1 / animationTime)));
                }
                else
                {
                    Color currentColor = highlightRenderer.material.color;
                    highlightRenderer.material.color = Color.Lerp(currentColor, _targetColor, Time.deltaTime * (1 / animationTime));
                }
            }
        }
    }
}
