using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    GameObject pauseCanvas;
    private void Awake()
    {
        pauseCanvas = GameObject.Find("PauseCanvas");
        pauseCanvas.SetActive(false);
    }
    private void OnMouseUp()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);

    }
}
