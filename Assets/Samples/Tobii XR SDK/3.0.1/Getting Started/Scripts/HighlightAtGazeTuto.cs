// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using Tobii.G2OM;
using UnityEngine;

namespace Tobii.XR.Examples.GettingStarted
{
    // Monobehaviour which implements the "IGazeFocusable" interface, meaning it will be called on when this object receives or loses focus
    public class HighlightAtGazeTuto : MonoBehaviour, IGazeFocusable
    {
        private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
        public Color highlightColor = Color.red;
        public float animationTime = 0.1f;
        private Renderer _renderer;
        private Color _originalColor;
        private Color _targetColor;
        private bool isGazing = false;

        // The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
        public void GazeFocusChanged(bool hasFocus)
        {
            // If this object received focus, fade the object's color to highlight color
            if (hasFocus)
            {
                Debug.Log($"포커스 됨: {gameObject.name}");
                _targetColor = highlightColor;
                isGazing = true; // 포커스가 잡혔을 때 상태 변경
            }
            // If this object lost focus, fade the object's color to its original color
            else
            {
                Debug.Log($"포커스 사라짐: {gameObject.name}");
                _targetColor = _originalColor;
                isGazing = false; // 포커스가 사라졌을 때 상태 변경
            }
        }

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.material.color;
            _targetColor = _originalColor;

            // 필드 초기화 디버깅
            Debug.Log("Start 메서드 호출됨");
        }

        private void Update()
        {
            // This lerp will fade the color of the object
            if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
            {
                _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
            }
            else // old standard rendering pipeline
            {
                _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
            }

            // 포커스가 잡힌 상태에서는 RandomVisibilityChanger.totalTime을 증가시킵니다.
            if (isGazing)
            {
                RandomVisibilityChanger.totalTime += Time.deltaTime;
                Debug.Log($"totalTime: {RandomVisibilityChanger.totalTime}");
            }
        }
    }
}
