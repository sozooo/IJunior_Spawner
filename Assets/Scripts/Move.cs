using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isMoving = true;

    private void Start()
    {
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (_isMoving)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;

            yield return null;
        }
    }

    
}
