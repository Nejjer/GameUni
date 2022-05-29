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
    private AudioSource _audio;

    private void Start()
    {
        _playerHealth =  GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
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
            _lastTimeAttack = Time.time;
        }
    }

    public void PlayAttackSound() => _audio.Play();
    
    public void Attack()
    {
        if (_isPlayerInTrigger) _playerHealth.GetDamage(damage);
    }
}