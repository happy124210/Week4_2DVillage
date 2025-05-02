using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private float offsetX;
    private float offsetY;
    
    public Vector2 minPosition;
    public Vector2 maxPosition;

    private void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    
    private void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        
        pos.x = Mathf.Clamp(pos.x, minPosition.x, maxPosition.x);
        pos.y = Mathf.Clamp(pos.y, minPosition.y, maxPosition.y);
        
        transform.position = pos;
    }
}