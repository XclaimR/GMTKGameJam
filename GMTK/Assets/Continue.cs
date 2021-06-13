using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    GameObject pauseCanvas;
    Pause p;
    private void Awake()
    {
        p = GameObject.Find("Pause").GetComponent<Pause>();
        pauseCanvas = GameObject.Find("PauseCanvas");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && p.isPaused)
        {
            p.isPaused = false;
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
       

    }
}
