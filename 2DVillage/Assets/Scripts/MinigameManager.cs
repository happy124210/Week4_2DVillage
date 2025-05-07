using System;
using Entity;
using UI;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private bool isPlaying;
    private StatHandler statHandler;
    
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Start()
    {
        UIManager.Instance.ShowIntroUI();
        statHandler.ResetHealth();
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
        isPlaying = true;
    }
    
}
