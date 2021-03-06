using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Mover _mover;

    private bool _isExist = false;
    private Vector3 _spawnPoint = new Vector3(-80, 2.4f, 0);
    private WaitForSeconds _sleep = new WaitForSeconds(2);

    private void Start()
    {
        _mover.Report += ReportDestraction;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (_isExist == false)
            {
                yield return _sleep;
                Coin coin = Instantiate(_coin, _spawnPoint, Quaternion.identity);
                _isExist = true;
            }
            yield return null;
        }
    }

    private void ReportDestraction()
    {
        _isExist = false;
    }
}
