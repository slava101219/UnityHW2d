using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ZombieMover : MonoBehaviour
{
    private float _speed = 0.5f;
    private Vector2 _rightTarget;
    private Vector2 _leftTarget;
    private float _ditance = 1f;
    private bool _goesToRight = true;
    private Animator _animator;
    private int _maxWaitTime = 3;

    private const string IsWalk = "isWalk";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rightTarget = transform.position;
        _rightTarget.x += _ditance;
        _leftTarget = transform.position;
        _leftTarget.x += -_ditance;
        StartCoroutine(Patrolling());
    }

    private IEnumerator Patrolling()
    {
        OnWalking(true);
        while (true)
        {
            if (transform.position.x >= _rightTarget.x - 0.01f)
            {
                _goesToRight = false;
                TurnBody();
                OnWalking(false);
                yield return new WaitForSeconds(Random.Range(0, _maxWaitTime));
                OnWalking(true);
            }
            else if (transform.position.x <= _leftTarget.x + 0.01f)
            {
                _goesToRight = true;
                TurnBody();
                OnWalking(false);
                yield return new WaitForSeconds(Random.Range(0, _maxWaitTime));
                OnWalking(true);
            }

            Move();
            yield return null;
        }
    }

    private void Move()
    {
        if (_goesToRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, _rightTarget, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _leftTarget, _speed * Time.deltaTime);
        }
    }

    private void TurnBody()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnWalking(bool isWalk)
    {
        _animator.SetBool(IsWalk, isWalk);
    }
}
