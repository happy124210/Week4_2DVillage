using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        [SerializeField] private Sprite fullHeart, halfHeart, emptyHeart;
        [SerializeField] private Image[] heartImages;
    
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private GameObject introUI;
        
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private GameObject clearPanel;

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }
    
        public void UpdateHearts(int currentHealth)
        {
            for (int i = 0; i < heartImages.Length; i++)
            {
                int heartValue = currentHealth - (i * 2);

                if (heartValue >= 2)
                    heartImages[i].sprite = fullHeart;
                else if (heartValue == 1)
                    heartImages[i].sprite = halfHeart;
                else
                    heartImages[i].sprite = emptyHeart;
            }
        }
    
    
        public void UpdateCoinUI(int count)
        {
            coinText.text = count.ToString();
        }
        
        
        public void ShowIntroUI()
        {
            introUI.SetActive(true);
        }


        public void HideIntroUI()
        {
            introUI.SetActive(false);
        }


        public void ShowResultUI(string result, int resultCoin)
        {
            resultPanel.SetActive(true);
            resultText.text = result;
            coinText.text = resultCoin.ToString();
        }


        public void ShowClearUI()
        {
            clearPanel.SetActive(true);
        }
    }
}
