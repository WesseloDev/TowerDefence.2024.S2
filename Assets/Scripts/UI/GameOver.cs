using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject panel;

    #region ConnectToAction
    void Start()
    {
        GameManager.gameOver += EnableGameOver;
    }

    void OnDestroy()
    {
        GameManager.gameOver -= EnableGameOver;
    }
    #endregion

    void EnableGameOver()
    {
        panel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
