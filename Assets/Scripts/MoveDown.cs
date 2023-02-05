using System;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float _speed;
    private void FixedUpdate()
    {
        Vector2 currentPosition = transform.position;

        currentPosition.y -= _speed * Time.fixedDeltaTime;
        
        transform.position = currentPosition;
    }
}
