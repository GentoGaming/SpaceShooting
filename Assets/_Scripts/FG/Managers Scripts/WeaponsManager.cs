using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.FG.Weapons;
using UnityEngine;

namespace _Scripts.FG.Managers_Scripts
{
    public class WeaponsManager : MonoBehaviour
    {
        public static WeaponsManager Instance = null;
        public GameObject slotsContainer;
        public GameObject player;
        public List<GameObject> weaponList;
        public GameObject explosionGameObject;
        private Transform[] _allWeaponsTransform;
        private GameObject _greenSlot;
        private List<GameObject> _slotsUI;
        private GameObject _weaponContainer;
        [NonSerialized] public bool IsShooting;
        [NonSerialized] public ParticleSystem particleSystemExplosion;
        public AudioSource AudioSource { get; set; }


        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;
            AudioSource = GetComponent<AudioSource>();
            particleSystemExplosion = explosionGameObject.GetComponent<ParticleSystem>();

            InitNewWeapon();
        }

        public void InitNewWeapon()
        {
            weaponList = new List<GameObject>();
            _slotsUI = new List<GameObject>();
            _weaponContainer = player.transform.Find("Weapons").gameObject;
            GetAllWeapons();
            GetAllWeaponsUISlots();
            ArrangeWeaponsUISlots();
        }

        private void GetAllWeaponsUISlots()
        {
            foreach (Transform oneSlot in slotsContainer.transform)
            {
                if (oneSlot.CompareTag($"Slots"))
                {
                    if (oneSlot.name.Equals("GreenSprite"))
                    {
                        _greenSlot = oneSlot.gameObject;
                        continue;
                    }
                    else
                    {
                        _slotsUI.Add(oneSlot.gameObject);
                    }
                }
            }
        }

        private void GetAllWeapons()
        {
            weaponList = new List<GameObject>();
            _allWeaponsTransform = _weaponContainer.GetComponentsInChildren<Transform>(true);

            foreach (Transform oneWeapon in _allWeaponsTransform)
            {
                if (oneWeapon.CompareTag($"Weapons"))
                {
                    weaponList.Add(oneWeapon.gameObject);
                    oneWeapon.gameObject.SetActive(false);
                }
            }
        }

        private void ArrangeWeaponsUISlots()
        {
            for (int i = 0; i < _slotsUI.Count; i++)
            {
                if (_slotsUI[i].transform.childCount > 0)
                {
                    Destroy(_slotsUI[i].transform.GetChild(0).gameObject);
                }

                if (i >= weaponList.Count) break;
                GameObject oneWeapon = weaponList[i];
                IWeapons oneWeaponUI = oneWeapon.gameObject.GetComponent<IWeapons>();
                GameObject weaponUI = Instantiate(oneWeaponUI.GetWeaponUI(), _slotsUI[i].transform);
            }
        }


        private void SetWeaponActive(int weaponIndex)
        {
            GetAllWeapons();
            weaponList[weaponIndex].SetActive(true);
            _greenSlot.transform.position = _slotsUI[weaponIndex].transform.position;
        }

        public void CoroutineBulletShots(float timeBetweenShots)
        {
            StartCoroutine(ReadyToShootAgain(timeBetweenShots));
        }

        private IEnumerator ReadyToShootAgain(float timeBetweenShots)
        {
            yield return new WaitForSeconds(timeBetweenShots);
            IsShooting = false;
        }

        public IWeapons GetWeapon(int weaponIndex)
        {
            SetWeaponActive(weaponIndex);
            return weaponList[weaponIndex].GetComponent<IWeapons>();
        }
    }
}