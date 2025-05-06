using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public Sprite heartFull, heartHalf, heartEmpty;
    public Image[] heartImages;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    
    public void UpdateHeartUI(int currentLife, int maxLife)
    {
        int heartCount = heartImages.Length;

        for (int i = 0; i < heartCount; i++)
        {
            int value = currentLife - (i * 2);
        
            if (value >= 2)
                heartImages[i].sprite = heartFull;
            else if (value == 1)
                heartImages[i].sprite = heartHalf;
            else
                heartImages[i].sprite = heartEmpty;

            heartImages[i].enabled = (i * 2 < maxLife);
        }
    }
}