using _Scripts.FG.Managers_Scripts;
using _Scripts.FG.ScriptableObjects;
using UnityEngine;

namespace _Scripts.FG.Weapons
{
    public class HomingMissile : MonoBehaviour, IWeapons
    {
        public GameObject weaponSlotUI;
        public float timeBetweenShots = .2f;
        public AudioClip audioClip;
        public Pool bulletInfo;
        [Range(6, 15)] public int bulletSpeed = 6;
        private AudioSource _audioSource;
        private GameObject _bullet;
        private PoolManager _poolManager;
        private WeaponsManager _weaponManager;

        private void Start()
        {
            _weaponManager = WeaponsManager.Instance;
            _audioSource = _weaponManager.AudioSource;
            _poolManager = PoolManager.Instance;
        }

        public void Shoot()
        {
            if (_weaponManager.IsShooting) return;
            _weaponManager.IsShooting = true;
            _weaponManager.CoroutineBulletShots(timeBetweenShots);
            _audioSource.clip = audioClip;
            _audioSource.Play();
            LaunchProjectile();
        }

        public void LaunchProjectile()
        {
            _bullet = _poolManager.SpawnObjFromPool(bulletInfo.poolTag,
                transform.TransformPoint(Vector3.zero) + (Vector3) bulletInfo.position[0], bulletInfo.rotation);
        }

        public GameObject GetWeaponUI()
        {
            return weaponSlotUI;
        }
    }
}