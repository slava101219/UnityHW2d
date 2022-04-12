using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _destroyed;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _destroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
