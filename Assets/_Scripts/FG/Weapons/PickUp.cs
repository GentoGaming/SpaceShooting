using _Scripts.FG.Managers_Scripts;
using UnityEngine;

namespace _Scripts.FG.Weapons
{
    public class PickUp : MonoBehaviour
    {
        public GameObject pickUpReference;
        public bool manyPickUps;
        public bool isAShield;

        private SpaceManager _spaceManager;

        private WeaponsManager _weaponsManager;

        // Start is called before the first frame update
        private void Start()
        {
            _weaponsManager = WeaponsManager.Instance;
            _spaceManager = SpaceManager.Instance;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isAShield)
            {
                _spaceManager.spaceShip.damageMultiplier = 0;
                Invoke(nameof(TurnOffShield), 5f);
                _spaceManager.playerShield.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                pickUpReference.SetActive(true);
                pickUpReference.tag = "Weapons";
                _weaponsManager.InitNewWeapon();
                gameObject.SetActive(false);
                _spaceManager.spaceShip.ChangeWeapon(pickUpReference.transform.GetSiblingIndex());
            }

            if (!manyPickUps)
            {
                Destroy(gameObject);
            }
        }

        private void TurnOffShield()
        {
            _spaceManager.spaceShip.damageMultiplier = 0.5f;
            _spaceManager.playerShield.gameObject.SetActive(false);
        }
    }
}