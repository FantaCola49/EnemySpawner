using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{
    private float _speed = 0.5f;
    private Vector2 _direction;
    private int _maxX = 12;
    private int _maxY = 12;

    private void Update()
    {
        if (transform.position.x >= _maxX || transform.position.y >= _maxY)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _direction = new Vector2(Random.Range(3, 15), Random.Range(3, 15));
        transform.Translate(_speed * _direction * Time.deltaTime, Space.World);
    }
}
