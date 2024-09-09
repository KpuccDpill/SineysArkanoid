using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private bool _isActive;
    public bool IsActive => _isActive;
    
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;
    private bool _changedDirectionThisFrame;

    public static event Action<Ball> OnBallDestroy;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isActive)
            return;
        
        if (collision.collider.GetComponent<Destroyer>() != null)
        {
            gameObject.SetActive(false);
            OnBallDestroy?.Invoke(this);
            
            return;
        }
        
        var collisionContactBounds = collision.GetContact(0).collider.bounds;

        if (collision.collider.GetComponent<Caret>() != null)
        {
            var halfSizeX = collisionContactBounds.extents.x;
            var collisionContact = collision.GetContact(0);
            var contactCenterDeltaX = collisionContact.point.x - collisionContactBounds.center.x;

            var directionY = Mathf.Max(0.1f, 1 - Mathf.Abs(contactCenterDeltaX / halfSizeX));
            var directionX = contactCenterDeltaX / halfSizeX;

            _direction = new Vector3(directionX, directionY);

            return;
        }

        if (!_changedDirectionThisFrame)
        {
            var closestPoint = collisionContactBounds.ClosestPoint(transform.position);

            if (_direction.y > 0)
            {
                if (Mathf.Abs(closestPoint.y - collisionContactBounds.min.y) < 0.0001f)
                {
                    _direction = new Vector3(_direction.x, -_direction.y);
                }
            }
            else
            {
                if (Mathf.Abs(closestPoint.y - collisionContactBounds.max.y) < 0.0001f)
                {
                    _direction = new Vector3(_direction.x, -_direction.y);
                }
            }

            if (_direction.x > 0)
            {
                if (Mathf.Abs(closestPoint.x - collisionContactBounds.min.x) < 0.0001f)
                {
                    _direction = new Vector3(-_direction.x, _direction.y);
                }
            }
            else
            {
                if (Mathf.Abs(closestPoint.x - collisionContactBounds.max.x) < 0.0001f)
                {
                    _direction = new Vector3(-_direction.x, _direction.y);
                }
            }

            _changedDirectionThisFrame = true;
        }

        var plank = collision.gameObject.GetComponent<Plank>();
        
        if (plank != null)
        {
            plank.TakeHit();
        }
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            _rigidbody2D.MovePosition(transform.position + _direction.normalized * speed);
            _changedDirectionThisFrame = false;
        }
    }

    public void Activate()
    {
        _isActive = true;
        _direction = new Vector3(1, 1);
    }

    public void ResetBall()
    {
        _isActive = false;
    }
}
