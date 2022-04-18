using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Animator _animator;

    private const string _offsetHorizontal = "horizontalMove";
    private const string _jumping = "jumping";
    private float _offsetY = -1.2f;
    private float _radius = 0.3f;
    private bool _facingRight = true;
    private float _horizontalMove = 0f;
    private Rigidbody2D _rigidbody;

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
        _animator.SetFloat(_offsetHorizontal, Mathf.Abs(_horizontalMove));
        TurnAsNeeded();
        Vector2 targetVelocity = new Vector2(_horizontalMove * 10f, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
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
            _animator.SetBool(_jumping, true);
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            _animator.SetBool(_jumping, false);
        }
    }

    private void TurnBody()
    {
        _facingRight = !_facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void TurnAsNeeded()
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
