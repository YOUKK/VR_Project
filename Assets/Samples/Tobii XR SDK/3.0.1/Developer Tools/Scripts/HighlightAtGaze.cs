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
        public Renderer childRenderer; // 인스펙터에서 할당할 수 있는 Renderer 변수
        private Color _originalColor;
        private Color _targetColor;
        private Color _childOriginalColor;
        private Color _childTargetColor;
        private static float lastGazeLeaveTime = 0; // 초기 값 설정
        private static GameObject lastGazedObject;
        private float gazeEnterTime;
        private static string desktopPath = @"D:\";
        //private static string desktopPath = @"C:\Users\emsys\Desktop";

        private static string csvFilePath = Path.Combine(desktopPath, "test.csv");
        private static bool fileHeaderWritten = false;

        private void AppendToCSV(string objectName, float gazeTransitionTime, float gazeDuration, Vector3 position)
        {
            if (!File.Exists(csvFilePath) || !fileHeaderWritten)
            {
                File.WriteAllText(csvFilePath, "ObjectName,gazeTransitionTime,gazeDuration,X,Y,Z\n");
                fileHeaderWritten = true;
            }

            using (StreamWriter sw = File.AppendText(csvFilePath))
            {
                sw.WriteLine($"{objectName},{gazeTransitionTime},{gazeDuration},{position.x},{position.y},{position.z}");
            }
        }

        public void GazeFocusChanged(bool hasFocus)
        {
            Vector3 currentPosition = this.gameObject.transform.position;
            string currentObjectName = gameObject.name;

            if (hasFocus)
            {
                Debug.Log($"포커스 됨: {currentObjectName} 저장, 위치: {currentPosition}");
                gazeEnterTime = Time.time; // 포커스 시작 시간 기록
                lastGazedObject = gameObject;
                _targetColor = highlightColor;
                _childTargetColor = highlightColor;
            }
            else
            {
                float gazeDuration = Time.time - gazeEnterTime;
                float gazeTransitionTime = 0f;
                if (lastGazedObject != null && lastGazedObject == this.gameObject)
                {
                    gazeTransitionTime = gazeEnterTime - lastGazeLeaveTime;
                }
                lastGazeLeaveTime = Time.time; // 포커스가 사라진 시간을 여기에서 업데이트

                Debug.Log($"포커스 잃음: {currentObjectName} 저장, 위치: {currentPosition}, 응시 시간: {gazeDuration}, 전환 시간: {gazeTransitionTime}");

                AppendToCSV(currentObjectName, gazeTransitionTime, gazeDuration, currentPosition);

                lastGazedObject = null;
                _targetColor = _originalColor;
                _childTargetColor = _childOriginalColor;
            }
        }

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.material.color;
            _targetColor = _originalColor;

            // 인스펙터에서 할당된 childRenderer의 원래 색상을 저장
            if (childRenderer != null)
            {
                _childOriginalColor = childRenderer.material.color;
                _childTargetColor = _childOriginalColor;
            }
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

            if (childRenderer != null)
            {
                if (childRenderer.material.HasProperty(_baseColor))
                {
                    childRenderer.material.SetColor(_baseColor, Color.Lerp(childRenderer.material.GetColor(_baseColor), _childTargetColor, Time.deltaTime / animationTime));
                }
                else
                {
                    childRenderer.material.color = Color.Lerp(childRenderer.material.color, _childTargetColor, Time.deltaTime / animationTime);
                }
            }
        }
    }
}
