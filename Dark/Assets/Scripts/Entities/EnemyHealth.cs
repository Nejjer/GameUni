using UnityEngine;

public class EnemyHealth : EntityHealth
{
    [SerializeField] private GameObject loot;
    [SerializeField] private GameObject fuel;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        EventManager.OnEndGame.AddListener(OnDeath);
    }

    protected override void OnDeath()
    {
        _animator.SetTrigger("Death");
    }
    
    protected override void OnGetDamage() => _animator.SetTrigger("GetDamage");
    
    public void Death()
    {
        Instantiate(Random.Range(0f, 1f) > 0.5 ? loot : fuel, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
