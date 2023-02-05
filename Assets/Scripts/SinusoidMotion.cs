using UnityEngine;

public class SinusoidMotion : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _rate;
    private float _sinusoid;
    private Vector2 _currentPosition;
    
    private void FixedUpdate()
    {
        _currentPosition = transform.position;
        _sinusoid = Mathf.Sin(_currentPosition.y * _rate) * _amplitude;
        
        _currentPosition.x = _sinusoid;
        transform.position = _currentPosition;
    }
}
