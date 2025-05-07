using Manager;
using UnityEngine;

namespace Entity
{
    public class PlayerController : BaseController
    {
        private Camera camera;

        protected override void Start()
        {
            base.Start();
            camera = Camera.main;
        }  
        
        
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            bool isWalking = movementDirection.magnitude > 0.1f;
            AudioManager.Instance.SetStepLoop(isWalking);
        }

        
        protected override void HandleAction()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            movementDirection = new Vector2(horizontal, vertical).normalized;

            Vector2 mousePosition = Input.mousePosition;
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
            lookDirection = (worldPos - (Vector2)transform.position);

            lookDirection = (lookDirection.magnitude < .9f) // deadzone
                ? Vector2.zero
                : lookDirection.normalized;
        }
    }
}
