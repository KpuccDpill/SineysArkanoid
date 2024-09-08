using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CaretMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    private const float DefaultYPosition = -4.5f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = new Vector2(0, DefaultYPosition);
    }

    private void FixedUpdate()
    {
        var mousePosition = Input.mousePosition;
        var worldPosX = Camera.main.ScreenToWorldPoint(mousePosition).x;

        _rigidbody2D.MovePosition(new Vector2(worldPosX, transform.position.y));
    }
}
