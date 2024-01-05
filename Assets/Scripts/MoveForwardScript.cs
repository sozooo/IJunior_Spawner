using System.Collections;
using UnityEngine;

public class MoveForwardScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    private bool _isMoving = true;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_isMoving)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;

            yield return null;
        }
    }
}
