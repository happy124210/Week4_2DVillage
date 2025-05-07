using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultUI : MonoBehaviour
    {
        [SerializeField] private GameObject introPanel;
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private GameObject clearPanel;
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private TextMeshProUGUI resultCoinText;

        public void ShowResult(string result, int resultCoin)
        {
            resultPanel.SetActive(true);
            resultText.text = result;
            resultCoinText.text = resultCoin.ToString();
        }

        public void ShowClear()
        {
            clearPanel.SetActive(true);
        }

        public void HideAll()
        {
            resultPanel.SetActive(false);
            clearPanel.SetActive(false);
        }
        
        
        public void ShowIntro()
        {
            introPanel.SetActive(true);
        }


        public void HideIntro()
        {
            introPanel.SetActive(false);
        }
    }
}