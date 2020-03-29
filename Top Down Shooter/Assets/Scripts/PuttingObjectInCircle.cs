using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuttingObjectInCircle : MonoBehaviour
{
    [SerializeField] private float radiusAmmoDrop = 0.5f;
    [SerializeField] private float moveSpeed = 2f;
    private Vector3 _targetPos;

    private void Start()
    {
        _targetPos = RandomCircle(transform.position, radiusAmmoDrop);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, Time.deltaTime * moveSpeed);
    }
    
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 position;
        position.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        position.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        position.z = center.z;
        return position;
    }
}
