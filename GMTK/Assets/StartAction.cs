using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAction : MonoBehaviour
{
    private void OnMouseUp()
    {
        SceneManager.LoadScene(3);
    }
}