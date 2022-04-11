using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpawnerCoin _spawnerCoin;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            SpawnerCoin.ChangeExist();
            Destroy(gameObject);
        }
    }
}
