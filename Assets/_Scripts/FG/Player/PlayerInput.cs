using _Scripts.FG.Managers_Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.FG.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerController _playerController;
        private InputActions _playerInputActions;
        private SpaceShip _spaceShip;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _spaceShip = GetComponentInChildren<SpaceShip>();
            _playerInputActions = new InputActions();

            _playerInputActions.Enable();

            _playerInputActions.PlayerShip.Movement.performed += OnMovement;
            _playerInputActions.PlayerShip.Movement.canceled += OnMovement;

            _playerInputActions.PlayerShip.Shooting.performed += OnShooting;
            _playerInputActions.PlayerShip.Shooting.canceled += OnShooting;

            _playerInputActions.PlayerShip.EquipWeapon.performed += OnWeaponChange;
        }

        private void OnDisable()
        {
            _playerInputActions.PlayerShip.Movement.performed -= OnMovement;
            _playerInputActions.PlayerShip.Movement.canceled -= OnMovement;

            _playerInputActions.PlayerShip.Shooting.performed -= OnShooting;
            _playerInputActions.PlayerShip.Shooting.performed -= OnShooting;

            _playerInputActions.PlayerShip.EquipWeapon.performed -= OnWeaponChange;
        }

        private void OnWeaponChange(InputAction.CallbackContext callbackContext)
        {
            for (int weaponIndex = 1; weaponIndex <= WeaponsManager.Instance.weaponList.Count; weaponIndex++)
            {
                if (callbackContext.control.name.Equals(weaponIndex.ToString()))
                {
                    _spaceShip.ChangeWeapon(weaponIndex - 1);
                    break;
                }
            }
        }


        private void OnShooting(InputAction.CallbackContext callbackContext)
        {
            _spaceShip.Shoot();
        }

        private void OnMovement(InputAction.CallbackContext callbackContext)
        {
            _playerController.Movement = callbackContext.ReadValue<Vector2>();
        }
    }
}