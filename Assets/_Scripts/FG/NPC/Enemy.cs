using System;
using _Scripts.FG.Managers_Scripts;
using _Scripts.FG.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.FG.NPC
{
    public class Enemy : MonoBehaviour, IEntity, IPooledObject
    {
        public bool canShoot;
        public bool moveInWavePattern; // sin , cos Movement
        [SerializeField] private float startMaxHealth = 15;
        public Pool bulletInfo1;
        public Pool bulletInfo2;
        public Pool bulletInfo3;
        private SpaceManager _spaceManager;

        public float timePeriod = 2;

        [Range(0, 30)] public float maxRandomHeight = 30f;
        private GameObject _bullet;

        private Pool _chosenBulletInfo;
        private Vector3 _nextPos;
        private PoolManager _poolManager;
        private Vector3 _position;
        private float _timeSinceStart;
        private WeaponsManager _weapons;
        private int _waveNumber;
        private void Awake()
        {
            _spaceManager = SpaceManager.Instance;
            _weapons = WeaponsManager.Instance;
            _poolManager = PoolManager.Instance;
            maxRandomHeight = Random.Range(0f, maxRandomHeight);
        }


        void Update()
        {
            if (moveInWavePattern)
            {
                _nextPos = transform.position;
                _nextPos.y = _position.y + maxRandomHeight +
                maxRandomHeight * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * _timeSinceStart);
                _timeSinceStart += Time.deltaTime;
                transform.position = _nextPos;
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collide");
        }

        public float Health { get; private set; }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (!(Health <= 0)) return;
            _spaceManager.UpdateScoreUI((int)startMaxHealth);
            gameObject.SetActive(false);
            _weapons.ParticleSystemExplosion.transform.position = transform.position;
            _weapons.ParticleSystemExplosion.Stop();
            _weapons.ParticleSystemExplosion.Play();
        }

        public void Shoot()
        {
            _waveNumber = _spaceManager.WaveNumber;
            if (_waveNumber <= 5)
            {
                if (_waveNumber > 2)
                {
                    _chosenBulletInfo = Random.Range(0, 100) <= 50 ? bulletInfo1 : bulletInfo3;
                }
                else
                {
                    _chosenBulletInfo = Random.Range(0, 100) <= 50 ? bulletInfo1 : bulletInfo2;
                }

                _bullet = _poolManager.SpawnObjFromPool(_chosenBulletInfo.poolTag,
                    transform.TransformPoint(Vector3.zero) + (Vector3) _chosenBulletInfo.position[0],
                    _chosenBulletInfo.rotation);

            }
        }


        public void OnObjectSpawn()
        {
            Health = startMaxHealth;
            _position = transform.position;
            maxRandomHeight /= 2;
            _timeSinceStart = (3 * timePeriod) / 4;

        }

        private void OnBecameVisible()
        {
            if (canShoot)
            {
                Shoot();
            }
        }
    }
}