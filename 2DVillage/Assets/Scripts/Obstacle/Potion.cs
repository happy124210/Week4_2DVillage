using Manager;
using UnityEngine;

namespace Obstacle
{
    public class Potion : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
        
            MinigameManager.Instance.hasPotion = true;
            AudioManager.Instance.PlayCoin();
            Destroy(gameObject);
        }
    }
}