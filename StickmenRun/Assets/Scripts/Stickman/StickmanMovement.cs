using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _sensitivity = 5;
    private float _startX;
    private Vector3 _elemetaryX;
    private float _xDirection;

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            _elemetaryX = Input.mousePosition;
            _startX = transform.position.x;
        }

        if (Input.GetMouseButton(0))
        {
            _xDirection = (_elemetaryX.x - Input.mousePosition.x) / _sensitivity;
            transform.position = new Vector3(_startX - _xDirection, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }

        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
    }
}
