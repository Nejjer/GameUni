using System;
using Player;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float _lastTimeAttack;
    [SerializeField] private float cooldown;
    [SerializeField] private int damage;
    private Animator _animator;
    private bool _isPlayerInTrigger;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth =  GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _isPlayerInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            _isPlayerInTrigger = false;
    }

    private void FixedUpdate()
    {
        if (_isPlayerInTrigger && Time.time - _lastTimeAttack >= cooldown)
        {
            _animator.SetTrigger("Attack");
        }
    }

    public void Attack()
    {
        _playerHealth.GetDamage(damage);
        _lastTimeAttack = Time.time;
    }
}