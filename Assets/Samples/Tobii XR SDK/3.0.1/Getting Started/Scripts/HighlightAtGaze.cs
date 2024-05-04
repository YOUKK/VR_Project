// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using System.IO;
using Tobii.G2OM;
using UnityEngine;

namespace Tobii.XR.Examples.GettingStarted
{
    //Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when the object receives focus
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

        // CSV 파일 경로를 설정합니다.
        private static string csvFilePath = Path.Combine(desktopPath, "test.csv");
        // 파일에 헤더가 기록되었는지 확인하기 위한 변수입니다.
        private static bool fileHeaderWritten = false;

        // 시선 데이터를 CSV 파일에 추가합니다.
        private void AppendToCSV(float gazeTransitionTime, float gazeDuration)
        {
            // 파일이 없거나 헤더를 아직 안 썼으면 헤더를 작성합니다.
            if (!File.Exists(csvFilePath) || !fileHeaderWritten)
            {
                // CSV 파일 헤더를 작성합니다.
                File.WriteAllText(csvFilePath, "gazeTransitionTime,gazeDuration\n");
                fileHeaderWritten = true;
            }

            // 스트림 라이터로 데이터를 파일에 추가합니다.
            using (StreamWriter sw = File.AppendText(csvFilePath))
            {
                sw.WriteLine($"{gazeTransitionTime},{gazeDuration}");
            }
        }


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


        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.material.color;
            _targetColor = _originalColor;
        }

        private void Update()
        {
            // 오브젝트의 색상을 점진적으로 변경합니다.
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
