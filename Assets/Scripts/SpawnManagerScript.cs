using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField, Min(1)] private float _timer;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _isON;

    private float _timeLeft = 0;

    private void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while(_isON)
        {
            _timeLeft += Time.deltaTime;

            if(_timeLeft >= _timer)
            {
                Instantiate(_prefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)].transform);

                _timeLeft = 0;
            }

            yield return null;
        }
    }
}
