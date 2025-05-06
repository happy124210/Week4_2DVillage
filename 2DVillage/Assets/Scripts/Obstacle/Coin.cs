using UnityEngine;
using Entity;

namespace Obstacle
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            var rc = other.GetComponent<ResourceController>();
            if (rc != null)
            {
                rc.AddCoin(100);
            }

            Destroy(gameObject);
        }
    }
}
