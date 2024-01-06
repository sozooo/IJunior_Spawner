using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(1)] private float _timer;
    [SerializeField] private Mover _cube;

    private List<Transform> _spawnPoints = new List<Transform>();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            _spawnPoints.Add(child);
        }
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Quaternion randomRotation = new Quaternion(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90), 0f);

        Mover clone = Instantiate(_cube, _spawnPoints[Random.Range(0, _spawnPoints.Count)]);

        clone.transform.rotation = randomRotation;
        
        yield return new WaitForSeconds(_timer);

        StartCoroutine(Spawn());
    }
}
