using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool IsExist = false;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
            IsExist = false;
        }
    }

    public void SetExisting()
    {
        IsExist = true;
    }
}
