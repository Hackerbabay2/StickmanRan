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
            // Получаем позицию мыши в экранных координатах
            Vector3 mousePosition = Input.mousePosition;

            // Преобразуем позицию мыши из экранных координат в мировые координаты
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.y));

            // Устанавливаем позицию объекта на уровне позиции мыши по оси X
            transform.position = new Vector3(worldMousePosition.x * _sensitivity, transform.position.y, transform.position.z);
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
