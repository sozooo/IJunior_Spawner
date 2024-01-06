using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(1)] private float _timer;
    [SerializeField] private GameObject _cube;
    [SerializeField] private bool _isON;

    private List<Vector3> _spawnPoints = new List<Vector3>();
    private float _timeLeft = 0;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            _spawnPoints.Add(child.position);
        }

        StartCoroutine(SpawnCube());
    }

    private IEnumerator SpawnCube()
    {
        while(_isON)
        {
            _timeLeft += Time.deltaTime;

            if(_timeLeft >= _timer)
            {
                Instantiate(_cube, _spawnPoints[Random.Range(0, _spawnPoints.Count)], new Quaternion(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90), 0f));

                _timeLeft = 0;
            }

            yield return null;
        }
    }
}
