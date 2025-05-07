using UnityEngine;
using UI;

namespace Entity
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] private float healthChangeDelay = .5f;
        
        private StatHandler statHandler;
        private AnimationHandler animationHandler;
    
        private float timeSinceLastChange = float.MaxValue;
        private float TimeSinceLastChange
        {
            get => timeSinceLastChange;
            set
            {
                timeSinceLastChange = value;
                if (timeSinceLastChange >= healthChangeDelay)
                    animationHandler.InvincibilityEnd();
            }
        }

        public int CurrentHealth { get; private set; }
        public int MaxHealth => statHandler.MaxHealth;
        public int CoinCount => statHandler.CoinCount;
        
        private const string CoinKey = "coinCount";

        private void Awake()
        {
            statHandler = GetComponent<StatHandler>();
            animationHandler = GetComponent<AnimationHandler>();
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
            LoadCoin();
            UIManager.Instance.UpdateCoinUI(statHandler.CoinCount);
        }

        private void Update()
        {
            if (TimeSinceLastChange < healthChangeDelay)
            {
                TimeSinceLastChange += Time.deltaTime;
            }
            
            // Debug Button
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
            {
                ResetCoin();
            }
        }

        public bool ChangeHealth(int amount)
        {
            if (amount == 0 || TimeSinceLastChange < healthChangeDelay)
                return false;

            TimeSinceLastChange = 0f;

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
            MinigameManager.Instance.GameOver();
        }
        
        
        public void AddCoin(int amount)
        {
            statHandler.AddCoin(amount);
            SaveCoin();
            UIManager.Instance.UpdateCoinUI(statHandler.CoinCount);
        }
        
        
        private void SaveCoin()
        {
            PlayerPrefs.SetInt(CoinKey, statHandler.CoinCount);
        }

        
        private void LoadCoin()
        {
            int saved = PlayerPrefs.GetInt(CoinKey, 0);
            statHandler.SetCoin(saved);
            UIManager.Instance.UpdateCoinUI(saved);
        }
        
        
        private void ResetCoin()
        {
            PlayerPrefs.DeleteKey(CoinKey);
            statHandler.SetCoin(0);
            UIManager.Instance.UpdateCoinUI(0);
        }
    }
}
