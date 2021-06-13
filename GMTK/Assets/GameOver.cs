using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameObject game;
    AudioSource audio;
    private void Awake()
    {
        game = GameObject.Find("GameOver");
        audio = GameObject.Find("Deathsound").GetComponent<AudioSource>();
    }

    private void Update()
    {
        BondHealth bh = GameObject.Find("Bond").GetComponent<BondHealth>();

        if(bh.ReturnHealth() <= 0)
        {
            game.GetComponent<Text>().enabled = true;
            audio.Play();
            Invoke("GameOverScene", 3f);
        }
    }

    void Pause()
    {
    }
    void GameOverScene()
    {
        SceneManager.LoadScene(4);
    }
}
