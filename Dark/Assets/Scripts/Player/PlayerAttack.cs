using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private Transform attackPos;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private int damage;
    [SerializeField] private Image reloadBar;
    private float _lastTimeAttack;
    private Animator _animator;
    private AudioSource _audio;

    private void Start()
    {
        _lastTimeAttack = Time.time;
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time - _lastTimeAttack >= cooldown)
        {
            if (Input.GetMouseButton(0))
            {
                _animator.SetTrigger("Attack");
                _audio.Play();
                var enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, enemyLayer);
                foreach (var enemy in enemies)
                {
                    enemy.GetComponent<EntityHealth>().GetDamage(damage);
                }

                _lastTimeAttack = Time.time;
            }
        }
        else
        {
            reloadBar.fillAmount = (Time.time - _lastTimeAttack) / cooldown;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
}