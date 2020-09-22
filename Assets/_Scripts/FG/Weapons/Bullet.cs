using _Scripts.FG.Managers_Scripts;
using _Scripts.FG.NPC;
using UnityEngine;

namespace _Scripts.FG.Weapons
{
    public partial class Bullet : MonoBehaviour, IPooledObject
    {
        public float bulletDamage;
        public float fieldOfImpact;
        public LayerMask layerToHit;
        public float bulletSpeed = 6;
        public bool isHomingMissile;
        public float rotationSpeed = 1f;
        private float _angle;
        private Rigidbody2D _bulletRigidBody;
        private Vector3 _direction;
        private Collider2D[] _enemyColliders = new Collider2D[9];
        private string _gameObjectTag;
        private bool _isFirstUse = true; // We get Rigidbody only once then reuse bullet .  
        private Quaternion _rotateToTarget;
        private SpaceManager _spaceManager;

        private GameObject _target;
        private WeaponsManager _weaponManager;

        private void Awake()
        {
            _spaceManager = SpaceManager.Instance;
            _target = _spaceManager.spaceShipGameObject;
            _weaponManager = WeaponsManager.Instance;
        }

        private void Update()
        {
            if (isHomingMissile) FindAnEnemyLockMissle();
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (transform.gameObject.layer.Equals(13))
            {
                if (!other.transform.gameObject.name.Equals("SpaceShip")) other.transform.gameObject.SetActive(false);
                gameObject.SetActive(false);
                _weaponManager.particleSystemExplosion.transform.position = transform.position;
                _weaponManager.particleSystemExplosion.Stop();
                _weaponManager.particleSystemExplosion.Play();
            }

            IEntity entity = other.gameObject.GetComponent<IEntity>();

            if (entity != null)
            {
                // If Bullet is a bomb than Field Of Impact is > 0 Than its a Bomb and it should damage nearby Enemy

                if (fieldOfImpact > 0)
                {
                    Physics2D.OverlapCircleNonAlloc(transform.position, fieldOfImpact, _enemyColliders, layerToHit);
                    foreach (Collider2D enemyCollider2D in _enemyColliders)
                    {
                        if (!(enemyCollider2D is null))
                        {
                            enemyCollider2D.gameObject.GetComponent<IEntity>()?.TakeDamage(bulletDamage);
                        }
                    }
                }
                else
                {
                    // Most bullets / non bombs will call this statement only
                    entity.TakeDamage(bulletDamage);
                }


                gameObject.SetActive(false);
            }
        }

        public void OnObjectSpawn()
        {
            if (_isFirstUse)
            {
                // called once only
                _gameObjectTag = transform.tag;
                _bulletRigidBody = GetComponent<Rigidbody2D>();
                _isFirstUse = !_isFirstUse;
            }

            if (!isHomingMissile)
            {
                Shoot();
            }
        }


        private void FollowTarget()
        {
            _direction = (_target.transform.position - transform.position).normalized;
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            _rotateToTarget = Quaternion.AngleAxis(_angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotateToTarget, Time.deltaTime * rotationSpeed);
            _bulletRigidBody.velocity = new Vector2(_direction.x * 100, _direction.y * 100);
        }

        private void FindAnEnemyLockMissle()
        {
            FollowTarget();
        }


        private void Shoot()
        {
            if (_gameObjectTag.Equals("enemyBullet"))
            {
                _bulletRigidBody.AddForce(new Vector2(-bulletSpeed * 1000, 0));
            }
            else
            {
                _bulletRigidBody.AddForce(new Vector2(bulletSpeed * 1000, 0));
            }
        }

        private enum LayerID
        {
            Enemy = 8,
            Player = 9
        }
    }
}