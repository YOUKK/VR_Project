// Copyright © 2018 – Property of Tobii AB (publ) - All Rights Reserved

using Tobii.G2OM;
using UnityEngine;

namespace Tobii.XR.Examples.DevTools
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
        private float focusStartTime; // 포커스 시작 시간을 기록할 변수
        private float focusEndTime; // 포커스 종료 시간을 기록할 변수

        //The method of the "IGazeFocusable" interface, which will be called when this object receives or loses focus
        public void GazeFocusChanged(bool hasFocus)
        {
            
            //If this object received focus, fade the object's color to highlight color
            if (hasFocus)
            {
                if (_targetColor != highlightColor)
                {
                    focusStartTime = Time.time;
                }
                _targetColor = highlightColor;
            }
            //If this object lost focus, fade the object's color to it's original color
            else
            {
                focusEndTime = Time.time;
                float focusDurationInSeconds = focusEndTime - focusStartTime;
                if (focusDurationInSeconds >= 0)
                {
                    Debug.Log("Focus duration: " + focusDurationInSeconds + " seconds");
                }
                else
                {
                    Debug.LogWarning("Invalid focus duration: " + focusDurationInSeconds + " seconds. Possible event order issue.");
                }
                _targetColor = _originalColor;
            }
        }

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _originalColor = _renderer.sharedMaterial.color;
            _targetColor = _originalColor;
            
        }

        private void Update()
        {
            //This lerp will fade the color of the object
            if (_renderer.sharedMaterial.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
            {
                _renderer.sharedMaterial.SetColor(_baseColor, Color.Lerp(_renderer.sharedMaterial.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
            }
            else // old standard rendering pipline
            {
                _renderer.sharedMaterial.color = Color.Lerp(_renderer.sharedMaterial.color, _targetColor, Time.deltaTime * (1 / animationTime));
            }
        }
    }
}