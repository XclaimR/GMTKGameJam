using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    GameObject pauseCanvas;
    private void Awake()
    {
        pauseCanvas = GameObject.Find("PauseCanvas");
    }
    private void OnMouseUp()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);

    }
}
