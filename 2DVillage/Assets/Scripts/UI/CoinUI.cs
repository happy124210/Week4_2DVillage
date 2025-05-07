using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;

        private void Start()
        {
            coinText.text = PlayerPrefs.GetInt("Coin", 0).ToString();
        }

        public void UpdateCoin(int count)
        {
            coinText.text = count.ToString();
        }
    }
}