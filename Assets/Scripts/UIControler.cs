using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControler : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject restartButton;
    void Start()
    {
        restartButton.SetActive(false);
        gameOverText.SetActive(false);
    }

    void OnEnable()
    {
        PlayerController.OnPlayerDead += GameOver;
    }


    void OnDisable()
    {
        PlayerController.OnPlayerDead -= GameOver;
    }

    public void GameOver()
    {
        restartButton.SetActive(true);
        gameOverText.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
