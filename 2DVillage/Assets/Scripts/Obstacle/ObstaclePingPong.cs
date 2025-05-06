using UnityEngine;
using Entity;

namespace Obstacle
{
    public class ObstaclePingPong : MonoBehaviour
    {
        public Vector2 moveDirection = Vector2.right;
        public float moveDistance = 3f;
        public float moveSpeed = 2f;
        private readonly int damageAmount = 1;

        private Vector3 startPos;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            startPos = transform.position;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
            Vector3 newPos = startPos + (Vector3)(moveDirection.normalized * offset);
            transform.position = newPos;
        
            float phase = Mathf.Repeat(Time.time * moveSpeed, moveDistance * 2f);
            bool movingBack = phase > moveDistance;

            if (spriteRenderer)
            {
                spriteRenderer.flipX = movingBack;
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
