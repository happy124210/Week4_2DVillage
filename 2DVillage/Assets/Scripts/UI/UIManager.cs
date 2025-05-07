using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        
        private HeartUI heartUI;
        private CoinUI coinUI;
        private ResultUI resultUI;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            
            heartUI = GetComponent<HeartUI>();
            coinUI = GetComponent<CoinUI>();
            resultUI = GetComponent<ResultUI>();
        }

        private void Start()
        {
            if (resultUI != null)
            {
                ShowIntroUI();
                HideAllUI();
            }
        }
        
        
        public void UpdateHearts(int currentHealth)
        {
            heartUI.UpdateHearts(currentHealth);
        }
    
    
        public void UpdateCoinUI(int count)
        {
            coinUI.UpdateCoin(count);
        }


        public void ShowIntroUI()
        {
            resultUI.ShowIntro();
        }


        public void HideIntroUI()
        {
            resultUI.HideIntro();
        }
        
        
        public void ShowResultUI(string result, int resultCoin)
        {
            resultUI.ShowResult(result, resultCoin);
        }

        public void ShowClearUI()
        {
            resultUI.ShowClear();
        }


        public void HideAllUI()
        {
            resultUI.HideAll();
        }
    }
}
