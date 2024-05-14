using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnObj : MonoBehaviour
{
    public Color highlightColor = Color.green;
    public float changeInterval = 5.0f; // 초록색으로 바뀌는 간격(초)
    private Renderer[] _renderers;
    // Start is called before the first frame update
    void Start()
    {
        _renderers = GetComponentsInChildren<Renderer>();
        StartCoroutine(RandomlyHighlightObjects());
    }
    private IEnumerator RandomlyHighlightObjects()
    {
        while (true)
        {
            foreach (Renderer renderer in _renderers)
            {
                renderer.material.color = renderer.material.HasProperty("_BaseColor") ? renderer.material.GetColor("_BaseColor") : renderer.material.color;
            }

            int randomIndex = Random.Range(0, _renderers.Length);
            Renderer randomRenderer = _renderers[randomIndex];
            randomRenderer.material.color = highlightColor;

            yield return new WaitForSeconds(changeInterval);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
