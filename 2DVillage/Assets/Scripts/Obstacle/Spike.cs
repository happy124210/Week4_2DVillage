using System.Collections;
using UnityEngine;
using Entity;

namespace Obstacle
{
    public class SpikeBehavior : MonoBehaviour
    {
        private Animator animator;
        private Collider2D spikeCollider;

        [SerializeField] private float interval = 2f;
        private readonly int damageAmount = 1;
    
        private static readonly int Pop = Animator.StringToHash("Pop");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spikeCollider = GetComponent<Collider2D>();
        }

        private void Start()
        {
            StartCoroutine(SpikeCycle());
        }

        private IEnumerator SpikeCycle()
        {
            while (true)
            {
                animator.SetTrigger(Pop);
                spikeCollider.enabled = true;
                yield return new WaitForSeconds(0.5f);
            
                spikeCollider.enabled = false;
                yield return new WaitForSeconds(interval);
            }
        }

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
