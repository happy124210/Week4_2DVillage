using UnityEngine;

namespace Entity
{
    public class StatHandler : MonoBehaviour
    {
        [SerializeField] private int health = 8; // 4hearts = 8
        public int MaxHealth => health;
        private int coinCount;
        public int CoinCount => coinCount;
    
        public int Health{
            get => health;
            set => health = Mathf.Clamp(value,0,8);
        } 
    
        [Range(1f, 20f)] [SerializeField] private float speed = 3;
        public float Speed{
            get => speed;
            set => speed = Mathf.Clamp(value,0,20);
        }
        
        
        public void SetCoin(int value)
        {
            coinCount = value;
        }
        
        public void AddCoin(int amount)
        {
            coinCount += amount;
        }
    }
}