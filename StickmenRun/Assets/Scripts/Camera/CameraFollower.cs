using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private float x = 0f, y = 10, z = -10f;
    [SerializeField] private Transform _target;
    [SerializeField] private float _damping;

    private void Start()
    {
       
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + x, transform.position.y + y, _target.position.z + z), _damping);
    }
}
