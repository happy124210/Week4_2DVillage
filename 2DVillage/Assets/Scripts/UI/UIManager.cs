using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        [SerializeField] private TextMeshProUGUI alertText;
        
        private Coroutine alertCoroutine;
        
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


        private void HideAllUI()
        {
            resultUI.HideAll();
        }
        
        
        public void ShowAlert(string msg, float duration = 2f)
        {
            if (alertCoroutine != null)
                StopCoroutine(alertCoroutine);
            alertCoroutine = StartCoroutine(AlertRoutine(msg, duration));
        }
        
        // TODO 추후 공용으로 쓸 수 있게 알림창으로 분리
        private IEnumerator AlertRoutine(string msg, float duration)
        {
            alertText.text = msg;
            alertText.gameObject.SetActive(true);
            yield return new WaitForSeconds(duration);
            alertText.gameObject.SetActive(false);
        }
    }
}
