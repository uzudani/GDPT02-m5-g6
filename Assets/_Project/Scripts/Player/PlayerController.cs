using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rb;
    private Vector3 _input;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Inputs();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Inputs()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        _input = new Vector3(h, 0f, v).normalized;
    }

    private void Movement()
    {
        Vector3 movement = _rb.position + _input * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(movement);
    }
}
