using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private bool _isExist = false;
    private Vector3 _spawnPoint = new Vector3(-80, 2.4f, 0);

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (_isExist == false)
            {
                yield return new WaitForSeconds(2);
                Instantiate(_coin, _spawnPoint, Quaternion.identity);
                _isExist = true;
            }
            yield return null;
        }
    }

    public void ReportDestraction()
    {
        _isExist = false;
    }
}
