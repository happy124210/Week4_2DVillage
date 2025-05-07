using System;
using UI;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    private bool isPlaying;
    
    private void Awake()
    {
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
        isPlaying = true;
    }
    
}
