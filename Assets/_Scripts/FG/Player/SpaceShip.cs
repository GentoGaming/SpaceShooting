using _Scripts.FG.Managers_Scripts;
using _Scripts.FG.NPC;
using _Scripts.FG.Weapons;
using UnityEngine;

namespace _Scripts.FG.Player
{
    public class SpaceShip : MonoBehaviour, IEntity
    {
        [SerializeField] private float startHealth = 100;
        public float damageMultiplier = 0.5f;
        public bool playerIsInvulnerable = false;
        private IEntity _entity;
        private SpaceManager _spaceManager;
        private Rigidbody2D _spaceShipRigidBody;
        private IWeapons _weapon;
        public float Shooting { get; set; }

        private void Start()
        {
            _spaceShipRigidBody = transform.GetComponent<Rigidbody2D>();
            _spaceManager = SpaceManager.Instance;
            Health = startHealth;
            ChangeWeapon(); // Equip Ship with the default Weapon
            UpdateHealthUI();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _entity = other.gameObject.GetComponent<IEntity>();

            if (_entity != null)
            {
                // Enemy will Blow up and Player ship will take half the enemy remaining Health as Damage . 
                TakeDamage(_entity.Health * damageMultiplier);
                _entity.TakeDamage(_entity.Health);
            }
        }

        public float Health { get; set; }

        public void TakeDamage(float damage)
        {
            Health -= (damage * damageMultiplier);
            if (Health < 0) Health = 0; // We must kill Player
            _spaceShipRigidBody.velocity = Vector2.zero;
            UpdateHealthUI();
        }

        public void Shoot()
        {
            _weapon.Shoot();
        }

        private float NormalizedHealth()
        {
            return Health / startHealth;
        }

        private void UpdateHealthUI()
        {
            _spaceManager.healthBar.SetSize(NormalizedHealth());
            _spaceManager.healthBar.SetColor(Health);
        }


        public void ChangeWeapon(int weaponIndex = 0)
        {
            if (WeaponsManager.Instance.weaponList.Count <= weaponIndex) return;
            _weapon = WeaponsManager.Instance.GetWeapon(weaponIndex);
        }
    }
}