using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeartUI : MonoBehaviour
    {
        [SerializeField] private Sprite fullHeart, halfHeart, emptyHeart;
        [SerializeField] private Image[] heartImages;

        public void Awake()
        {
            fullHeart = Resources.Load<Sprite>("Heart/FullHeart");
            halfHeart = Resources.Load<Sprite>("Heart/HalfHeart");
            emptyHeart = Resources.Load<Sprite>("Heart/EmptyHeart");
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
    }
}