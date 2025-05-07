using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinText;
        
        public void UpdateCoin(int count)
        {
            coinText.text = count.ToString();
        }
    }
}