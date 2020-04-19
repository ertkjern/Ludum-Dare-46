using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 1.0f;

    private GameObject _player;
    private bool isAttacking;
    private Animator _animation;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _animation = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (isAttacking)
        {
            RotateTowardsPlayer();
            Move();
        }
    }

    private void RotateTowardsPlayer()
    {
        var offset = 90f;
        Vector2 direction = (Vector2)_player.transform.position - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            isAttacking = true;
            if (_animation)
            {
                _animation.SetBool("isAttacking", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            isAttacking = false;
            if (_animation)
            {
                _animation.SetBool("isAttacking", false);
            }
        }
    }
}
