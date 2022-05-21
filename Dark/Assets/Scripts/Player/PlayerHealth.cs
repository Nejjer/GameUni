using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerHealth : EntityHealth
    {
        [SerializeField] private float delayReload = 3;
        private bool _isAlive = true;

        public bool IsAlive
        {
            get => _isAlive;
        }

        private Collider2D _collider;
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _collider = GetComponent<CapsuleCollider2D>();
        }

        protected override void OnDeath()
        {
            _animator.SetTrigger("Death");
            //_collider.enabled = false;
            _isAlive = false;
        }

        public void Death()
        {
            StartCoroutine(ReloadScene());
        }

        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(delayReload);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}