using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealth : EntityHealth
    {
        [SerializeField] private float delayReloadScene = 3;
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
        }

        protected override void OnGetDamage() => HPBar.fillAmount = (float)currentHealth / health;
        public void Death() => StartCoroutine(ReloadScene());

        public void AddHeath(int addedHealth) => currentHealth += addedHealth;

        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(delayReloadScene);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}