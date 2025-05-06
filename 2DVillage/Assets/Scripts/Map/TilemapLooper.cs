using UnityEngine;

namespace Map
{
    public class TilemapLooper : MonoBehaviour
    {
        [SerializeField] private Transform[] tilemaps;
        [SerializeField] private float speed = 2f;
        [SerializeField] private float tilemapWidth = 20f;

        private void Update()
        {
            foreach (var t in tilemaps)
            {
                t.position += Vector3.left * (speed * Time.deltaTime);
            
                if (t.position.x <= -tilemapWidth)
                {
                    float maxX = GetRightmostTilemapX();
                    t.position = new Vector3(maxX + tilemapWidth, t.position.y, t.position.z);
                }
            }
        }

        private float GetRightmostTilemapX()
        {
            float max = float.MinValue;
            foreach (var t in tilemaps)
            {
                if (t.position.x > max)
                    max = t.position.x;
            }
            return max;
        }
    }
}
