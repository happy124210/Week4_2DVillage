using UnityEngine;

namespace Entity
{
    public class AnimationHandler : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int IsDamaged = Animator.StringToHash("IsDamaged");

        protected Animator animator;

        protected virtual void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        
        public void Move(Vector2 obj)
        {
            animator.SetBool(IsMoving, obj.magnitude > .5f);
        }

        
        public void Damage()
        {
            animator.SetBool(IsDamaged, true);
        }

        
        public void InvincibilityEnd()
        {
            animator.SetBool(IsDamaged, false);
        }
    }
}

