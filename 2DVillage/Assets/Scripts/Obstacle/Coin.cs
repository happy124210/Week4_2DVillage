using UnityEngine;
using Entity;

namespace Obstacle
{
    public class Coin : MonoBehaviour
    {
        private const int CoinAmount = 100;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            var rc = other.GetComponent<ResourceController>();
            if (rc != null)
            {
                rc.AddCoin(CoinAmount);
            }

            Destroy(gameObject);
        }
    }
}