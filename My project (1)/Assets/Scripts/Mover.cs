using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Animator _animator;

    private float _offsetY = -1.2f;
    private float _radius = 0.3f;
    private bool _facingRight = true;
    private float _horizontalMove = 0f;
    private Rigidbody2D _rigidbody;

    private const string OffsetHorizontal = "horizontalMove";
    private const string Jumping = "jumping";

    public delegate void InformantOfDestruction();
    public event InformantOfDestruction Report;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {       
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _speed;
        _animator.SetFloat(OffsetHorizontal, Mathf.Abs(_horizontalMove));
        Turn();
        Vector2 targetVelocity = new Vector2(_horizontalMove * 10f, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            Report?.Invoke();
            Destroy(coin.gameObject);
        }
    }

    private bool CheckOntheGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + _offsetY), _radius);
        return colliders.Length > 1;
    } 

    private void Jump()
    {
        if (CheckOntheGround() && Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool(Jumping, true);
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            _animator.SetBool(Jumping, false);
        }
    }

    private void TurnBody()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void Turn()
    {
        if (_horizontalMove < 0 && _facingRight)
        {
            TurnBody();
        }
        else if (_horizontalMove > 0 && !_facingRight)
        {
            TurnBody();
        }
    }
}
