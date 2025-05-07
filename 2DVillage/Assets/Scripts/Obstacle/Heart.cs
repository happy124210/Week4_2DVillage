using UnityEngine;
using Entity;
using Manager;

namespace Obstacle
{
    public class Heart : MonoBehaviour
    {
        private const int FullHeartAmount = 2;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            ResourceController rc = other.GetComponent<ResourceController>();
            if (rc != null && rc.CurrentHealth < rc.MaxHealth)
            {
                rc.ChangeHealth(FullHeartAmount);
                AudioManager.Instance.PlayCoin();
                Destroy(gameObject);
            }
        }
    }
}
