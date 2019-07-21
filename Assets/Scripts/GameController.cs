using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

 

    private UIControler ui_controller;

    private bool gameOver;
    private bool gameNeedRestart;

    
    void Awake()
    {
        gameOver = false;
        gameNeedRestart = false;
        ui_controller = FindObjectOfType<UIControler>();
        
    }
    void OnEnable()
    {
        PlayerController.OnPlayerDead += GameOver;
    }


    void OnDisable()
    {
        PlayerController.OnPlayerDead -= GameOver;
    }
    void Update()
    {
        if(gameNeedRestart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameNeedRestart = true;
        ui_controller.GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public bool isGameOver()
    {
        return gameOver;
    }

}
