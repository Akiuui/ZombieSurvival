using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    Running,
    Over,
    Paused,
    Map,
}

public class GameManager : MonoBehaviour
{
    public GameState currentState { get; private set; }

    public GameObject mainMenuUI;
    public GameObject gameOverUI;
    public GameObject runningUI;
    public GameObject pausedUI;
    public GameObject mapUI;

    private void Start()
    {
        ChangeState(GameState.Running);
    }


    private void ChangeState(GameState newState) {

        currentState = newState;

        mainMenuUI.SetActive(false);
        runningUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        mapUI.SetActive(false);

        switch (currentState)
        {

            case GameState.MainMenu:
                Time.timeScale = 0f;
                mainMenuUI.SetActive(true);
                break;

            case GameState.Running:
                Time.timeScale = 1f;
                runningUI.SetActive(true);
                break;

            case GameState.Paused:
                Time.timeScale = 0f;
                pausedUI.SetActive(true);
                break;

            case GameState.Over:
                Time.timeScale = 0f;
                gameOverUI.SetActive(true);
                break;

            case GameState.Map:
                Time.timeScale = 1f;
                mapUI.SetActive(true);
                break;
        }
    }
    public void ShowMap() { 
        ChangeState(GameState.Map);
    }

    public void StartGame()
    {
        ChangeState(GameState.MainMenu);
    }

    public void PauseGame()
    {
        ChangeState(GameState.Paused);
    }

    public void ResumeGame()
    {
        ChangeState(GameState.Running);
    }

    public void GameOver()
    {
        ChangeState(GameState.Over);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}