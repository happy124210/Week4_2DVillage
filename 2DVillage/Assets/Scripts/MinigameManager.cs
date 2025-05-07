using System;
using Entity;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance { get; private set; }
    
    private bool isPlaying;
    private bool isClear;
    public bool hasPotion;
    private StatHandler statHandler;
    private int coinBeforeGame;
    
    private void Awake()
    {
        if (Instance == null) Instance = this;

        statHandler = FindObjectOfType<StatHandler>();
        Time.timeScale = 0f;
    }

    
    private void Start()
    {
        UIManager.Instance.ShowIntroUI();
    }
    
    
    public void OnStartButtonPressed()
    {
        if (isPlaying) return;

        UIManager.Instance.HideIntroUI();
        Time.timeScale = 1f;
        StartGame();
    }
    
    
    private void StartGame()
    {
        coinBeforeGame = statHandler.CoinCount;
        isPlaying = true;
        
    }
    
    
    public void GameOver()
    {
        EndGame("Game Over");
    }

    
    private void GameClear()
    {
        EndGame("Game Clear");
    }

    
    private void EndGame(string result)
    {
        Time.timeScale = 0f;
        int resultCoin = statHandler.CoinCount - coinBeforeGame;
        UIManager.Instance.ShowResultUI(result, resultCoin);
        if (isClear) UIManager.Instance.ShowClearUI();
    }
    
    
    public void OnExitButtonPressed()
    {
        if (!hasPotion) return;
        
        isPlaying = false;
        isClear = true;
        GameClear();
    }


    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    
}
