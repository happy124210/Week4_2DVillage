using UnityEngine;
using Entity;

namespace Obstacle
{
    public class Hole : MonoBehaviour
    {
        private readonly int damageAmount = 2;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ResourceController rc = other.GetComponent<ResourceController>();
                if (rc != null)
                {
                    rc.ChangeHealth(-damageAmount);
                }
            }
        }
    }
}

