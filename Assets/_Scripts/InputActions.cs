// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerShip"",
            ""id"": ""8842c956-f962-4830-973c-7e4538d3f38f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""186defb2-1bcc-4f2c-93a0-287f8ba0dc49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""4f8db389-024e-40c7-af18-0c0b0ffe0f8f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EquipWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""a2378471-d995-4727-a4fe-4f5c1dffcf85"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""02d57f59-aa56-4c8d-bd70-65e235d28bae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4b28dacf-669c-4ab6-89ce-49a257e42c79"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7870d983-d22d-4a02-89fc-d8ce935ff027"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dc75d123-01e1-4497-af9e-8b199dc0ba90"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f9412bb3-5d33-4549-97c9-3e97d07ba6ad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""016079f2-1913-410c-8b34-61f85578d2b2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2ac2404-af2e-4bfd-85fa-4893febc9160"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EquipWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fc2bdcf-4fc3-4015-a3d2-61eb918ca663"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EquipWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb9eafd9-a978-455f-9fd5-a81c088cdc03"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EquipWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerShip
        m_PlayerShip = asset.FindActionMap("PlayerShip", throwIfNotFound: true);
        m_PlayerShip_Movement = m_PlayerShip.FindAction("Movement", throwIfNotFound: true);
        m_PlayerShip_Shooting = m_PlayerShip.FindAction("Shooting", throwIfNotFound: true);
        m_PlayerShip_EquipWeapon = m_PlayerShip.FindAction("EquipWeapon", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerShip
    private readonly InputActionMap m_PlayerShip;
    private IPlayerShipActions m_PlayerShipActionsCallbackInterface;
    private readonly InputAction m_PlayerShip_Movement;
    private readonly InputAction m_PlayerShip_Shooting;
    private readonly InputAction m_PlayerShip_EquipWeapon;
    public struct PlayerShipActions
    {
        private @InputActions m_Wrapper;
        public PlayerShipActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerShip_Movement;
        public InputAction @Shooting => m_Wrapper.m_PlayerShip_Shooting;
        public InputAction @EquipWeapon => m_Wrapper.m_PlayerShip_EquipWeapon;
        public InputActionMap Get() { return m_Wrapper.m_PlayerShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerShipActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerShipActions instance)
        {
            if (m_Wrapper.m_PlayerShipActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnMovement;
                @Shooting.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnShooting;
                @Shooting.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnShooting;
                @Shooting.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnShooting;
                @EquipWeapon.started -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnEquipWeapon;
                @EquipWeapon.performed -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnEquipWeapon;
                @EquipWeapon.canceled -= m_Wrapper.m_PlayerShipActionsCallbackInterface.OnEquipWeapon;
            }
            m_Wrapper.m_PlayerShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shooting.started += instance.OnShooting;
                @Shooting.performed += instance.OnShooting;
                @Shooting.canceled += instance.OnShooting;
                @EquipWeapon.started += instance.OnEquipWeapon;
                @EquipWeapon.performed += instance.OnEquipWeapon;
                @EquipWeapon.canceled += instance.OnEquipWeapon;
            }
        }
    }
    public PlayerShipActions @PlayerShip => new PlayerShipActions(this);
    public interface IPlayerShipActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShooting(InputAction.CallbackContext context);
        void OnEquipWeapon(InputAction.CallbackContext context);
    }
}
