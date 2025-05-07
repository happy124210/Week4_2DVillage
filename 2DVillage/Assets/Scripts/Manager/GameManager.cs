using Entity;
using UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        Time.timeScale = 1;
        
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
