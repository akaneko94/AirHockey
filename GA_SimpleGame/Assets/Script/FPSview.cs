using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSview : MonoBehaviour
{
    private float fps;
    private Text fpsText;

    void Start()
    {
        fpsText = GetComponentInChildren<Text>();

    }
    private void Update()
    {
        fps = 1f / Time.deltaTime;
        Debug.Log(fps);
        fpsText.text = fps.ToString();
    }
}
