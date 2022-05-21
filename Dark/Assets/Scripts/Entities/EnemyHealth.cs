using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    [SerializeField] private GameObject loot;
    [SerializeField] private GameObject fuel;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void OnDeath()
    {
        _animator.SetTrigger("Death");
    }

    public void Death()
    {
        Instantiate(Random.Range(0, 1) > 0.5 ? loot : fuel, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
