using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Loot;
    [SerializeField] private GameObject Fuel;
    [SerializeField] private int health = 100;
    public void GetDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Instantiate(Random.Range(0, 1) > 0.5 ? Loot : Fuel, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
