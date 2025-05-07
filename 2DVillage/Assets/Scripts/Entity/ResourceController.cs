using UnityEngine;
using UI;

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
        public int CoinCount => statHandler.CoinCount;
        
        private const string CoinKey = "coin_count";

        private void Awake()
        {
            statHandler = GetComponent<StatHandler>();
            animationHandler = GetComponent<AnimationHandler>();
            baseController = GetComponent<BaseController>();
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
            LoadCoin();
            UIManager.Instance.UpdateCoinUI(statHandler.CoinCount);
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
            
            // Debug Button
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.R))
            {
                ResetCoin();
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
