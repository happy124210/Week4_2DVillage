using UnityEngine;
using Entity;

namespace Obstacle
{
    public class Heart : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            ResourceController rc = other.GetComponent<ResourceController>();
            if (rc != null && rc.CurrentHealth < rc.MaxHealth)
            {
                rc.ChangeHealth(2);
                Destroy(gameObject);
            }
        }
    }
}
