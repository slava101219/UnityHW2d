using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private float _xCordinate = -80;
    private float _yCordinate = 2.4f;
    private float _zCordinate = 0;
    private Vector3 _spawnPoint;

    private void Start()
    {
        _spawnPoint = new Vector3(_xCordinate, _yCordinate, _zCordinate);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (_coin.IsExist == false)
            {
                yield return new WaitForSeconds(2);
                Instantiate(_coin, _spawnPoint, Quaternion.identity);
                _coin.SetExisting();
            }
            yield return null;
        }
    }
}
