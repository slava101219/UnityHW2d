using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PatrolController : MonoBehaviour
{
    private float _speed = 0.5f;
    private Vector2 _rightTarget;
    private Vector2 _leftTarget;
    private float _ditance = 1f;
    private bool _goesToRight = true;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rightTarget = transform.position;
        _rightTarget.x += _ditance;
        _leftTarget = transform.position;
        _leftTarget.x += -_ditance;
        StartCoroutine(CheckAchieveTarget());
    }

    void FixedUpdate()
    {

    }

    private IEnumerator CheckAchieveTarget()
    {
        WalkingEnable();
        while (true)
        {
            if (transform.position.x >= _rightTarget.x - 0.01f)
            {
                _goesToRight = false;
                TurnBody();
                WalkingDisable();
                yield return new WaitForSeconds(Random.Range(0, 3));
                WalkingEnable();
            }
            else if (transform.position.x <= _leftTarget.x + 0.01f)
            {
                _goesToRight = true;
                TurnBody();
                WalkingDisable();
                yield return new WaitForSeconds(Random.Range(0, 3));
                WalkingEnable();
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

    private void WalkingEnable()
    {
        _animator.SetBool("isWalk", true);
    }

    private void WalkingDisable()
    {
        _animator.SetBool("isWalk", false);
    }
}
