using UnityEngine;

namespace Entity
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] private float healthChangeDelay = .5f;

        private BaseController baseController;
        private StatHandler statHandler;
        private AnimationHandler animationHandler;
    
        private float timeSinceLastChange = float.MaxValue;

        public int CurrentHealth { get; private set; }
        public int MaxHealth => statHandler.MaxHealth;

        private void Awake()
        {
            statHandler = GetComponent<StatHandler>();
            animationHandler = GetComponent<AnimationHandler>();
            baseController = GetComponent<BaseController>();
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        private void Update()
        {
            if (timeSinceLastChange < healthChangeDelay)
            {
                timeSinceLastChange += Time.deltaTime;
                if (timeSinceLastChange >= healthChangeDelay)
                {
                    animationHandler.InvincibilityEnd();
                }
            }
        }

        public bool ChangeHealth(int amount)
        {
            if (amount == 0 || timeSinceLastChange < healthChangeDelay)
                return false;

            timeSinceLastChange = 0f;

            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);

            if (amount < 0)
            {
                animationHandler.Damage();
            }

            if (CurrentHealth <= 0)
            {
                Death();
            }

            UIManager.Instance.UpdateHearts(CurrentHealth);
            return true;
        }

        private void Death()
        {

        }

    }
}
