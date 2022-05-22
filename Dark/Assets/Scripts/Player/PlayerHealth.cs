using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : EntityHealth
    {
        [SerializeField] private Image HPBar;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private bool _isAlive = true;
        public bool IsAlive => _isAlive;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        protected override void OnDeath()
        {
            _animator.SetTrigger("Death");
            _isAlive = false;
            EventManager.SendRestartGame();
        }

        protected override void OnGetDamage() => HPBar.fillAmount = (float)currentHealth / health;
        public void AddHeath(int addedHealth) => currentHealth += addedHealth;

    }
}