using UnityEngine;

namespace Player
{
    public class PlayerHealth : EntityHealth
    {
        public override void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}