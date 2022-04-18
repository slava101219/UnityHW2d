using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public delegate void InformantOfDestruction();
    public event InformantOfDestruction Report;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Report?.Invoke();
            Destroy(gameObject);
        }
    }
}
