using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;

    public float Speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<CaretMovement>() != null)
        {
            var collisionContact = collision.GetContact(0);
            var collisionContactBounds = collision.GetContact(0).collider.bounds;

            var contactCenterDelta = collisionContact.point.x - collisionContactBounds.center.x;
            var halfSize = collisionContactBounds.size.x / 2f;

            var directionY = Mathf.Max(0.1f, 1 - Mathf.Abs(contactCenterDelta / halfSize));
            var directionX = contactCenterDelta / halfSize;

            _direction = new Vector3(directionX, directionY);
        }
        else if (collision.collider.GetComponent<TopWall>() != null)
        {
            _direction = new Vector3(_direction.x, -_direction.y);
        }
        else if (collision.collider.GetComponent<Destroyer>() != null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            _direction = new Vector3(-_direction.x, _direction.y);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(transform.position + _direction.normalized * Speed);
    }
}
