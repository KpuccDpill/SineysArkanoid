using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;

    public float speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Destroyer>() != null)
        {
            gameObject.SetActive(false);
            
            return;
        }
        
        var collisionContactBounds = collision.GetContact(0).collider.bounds;

        if (collision.collider.GetComponent<CaretMovement>() != null)
        {
            var halfSizeX = collisionContactBounds.extents.x;
            var collisionContact = collision.GetContact(0);
            var contactCenterDeltaX = collisionContact.point.x - collisionContactBounds.center.x;

            var directionY = Mathf.Max(0.1f, 1 - Mathf.Abs(contactCenterDeltaX / halfSizeX));
            var directionX = contactCenterDeltaX / halfSizeX;

            _direction = new Vector3(directionX, directionY);

            return;
        }

        var closestPoint = collisionContactBounds.ClosestPoint(transform.position);

        if (Math.Abs(closestPoint.y - collisionContactBounds.min.y) < 0.001f ||
            Math.Abs(closestPoint.y - collisionContactBounds.max.y) < 0.001f)
        {
            _direction = new Vector3(_direction.x, -_direction.y);
        }
        
        if (Math.Abs(closestPoint.x - collisionContactBounds.min.x) < 0.001f ||
            Math.Abs(closestPoint.x - collisionContactBounds.max.x) < 0.001f)
        {
            _direction = new Vector3(-_direction.x, _direction.y);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + _direction.normalized * speed);
    }
}
