// GENERATED AUTOMATICALLY FROM 'Assets/MDB/Scripts/Input/PowerUpInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace mdb.memesteroid.input
{
    public class @PowerUpInput : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PowerUpInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PowerUpInput"",
    ""maps"": [
        {
            ""name"": ""PowerUp"",
            ""id"": ""d190c39a-4738-4014-a36c-7df901c34037"",
            ""actions"": [
                {
                    ""name"": ""PowerUp1"",
                    ""type"": ""Button"",
                    ""id"": ""0d421460-c78c-406b-84ba-77a79749b137"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PowerUp2"",
                    ""type"": ""Button"",
                    ""id"": ""59db1fd4-0bd9-4663-af82-edfa4d1dd747"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PowerUp3"",
                    ""type"": ""Button"",
                    ""id"": ""ecd986be-1bf2-448b-9f97-53efb70a11ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PowerUp4"",
                    ""type"": ""Button"",
                    ""id"": ""4aac65c0-d3d2-4d7d-ae87-e81981265c34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e54bea85-f95b-4e36-87dc-a5a9383db1f1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerUp1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8406311b-feeb-4638-902e-b789a13bcc80"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerUp2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1a1993c-7f94-4a45-ad13-b308953df77f"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerUp3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe24d723-f2bb-4b28-83a1-8d36dfca7a83"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PowerUp4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PowerUp
            m_PowerUp = asset.FindActionMap("PowerUp", throwIfNotFound: true);
            m_PowerUp_PowerUp1 = m_PowerUp.FindAction("PowerUp1", throwIfNotFound: true);
            m_PowerUp_PowerUp2 = m_PowerUp.FindAction("PowerUp2", throwIfNotFound: true);
            m_PowerUp_PowerUp3 = m_PowerUp.FindAction("PowerUp3", throwIfNotFound: true);
            m_PowerUp_PowerUp4 = m_PowerUp.FindAction("PowerUp4", throwIfNotFound: true);
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

        // PowerUp
        private readonly InputActionMap m_PowerUp;
        private IPowerUpActions m_PowerUpActionsCallbackInterface;
        private readonly InputAction m_PowerUp_PowerUp1;
        private readonly InputAction m_PowerUp_PowerUp2;
        private readonly InputAction m_PowerUp_PowerUp3;
        private readonly InputAction m_PowerUp_PowerUp4;
        public struct PowerUpActions
        {
            private @PowerUpInput m_Wrapper;
            public PowerUpActions(@PowerUpInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @PowerUp1 => m_Wrapper.m_PowerUp_PowerUp1;
            public InputAction @PowerUp2 => m_Wrapper.m_PowerUp_PowerUp2;
            public InputAction @PowerUp3 => m_Wrapper.m_PowerUp_PowerUp3;
            public InputAction @PowerUp4 => m_Wrapper.m_PowerUp_PowerUp4;
            public InputActionMap Get() { return m_Wrapper.m_PowerUp; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PowerUpActions set) { return set.Get(); }
            public void SetCallbacks(IPowerUpActions instance)
            {
                if (m_Wrapper.m_PowerUpActionsCallbackInterface != null)
                {
                    @PowerUp1.started -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp1;
                    @PowerUp1.performed -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp1;
                    @PowerUp1.canceled -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp1;
                    @PowerUp2.started -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp2;
                    @PowerUp2.performed -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp2;
                    @PowerUp2.canceled -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp2;
                    @PowerUp3.started -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp3;
                    @PowerUp3.performed -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp3;
                    @PowerUp3.canceled -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp3;
                    @PowerUp4.started -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp4;
                    @PowerUp4.performed -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp4;
                    @PowerUp4.canceled -= m_Wrapper.m_PowerUpActionsCallbackInterface.OnPowerUp4;
                }
                m_Wrapper.m_PowerUpActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @PowerUp1.started += instance.OnPowerUp1;
                    @PowerUp1.performed += instance.OnPowerUp1;
                    @PowerUp1.canceled += instance.OnPowerUp1;
                    @PowerUp2.started += instance.OnPowerUp2;
                    @PowerUp2.performed += instance.OnPowerUp2;
                    @PowerUp2.canceled += instance.OnPowerUp2;
                    @PowerUp3.started += instance.OnPowerUp3;
                    @PowerUp3.performed += instance.OnPowerUp3;
                    @PowerUp3.canceled += instance.OnPowerUp3;
                    @PowerUp4.started += instance.OnPowerUp4;
                    @PowerUp4.performed += instance.OnPowerUp4;
                    @PowerUp4.canceled += instance.OnPowerUp4;
                }
            }
        }
        public PowerUpActions @PowerUp => new PowerUpActions(this);
        public interface IPowerUpActions
        {
            void OnPowerUp1(InputAction.CallbackContext context);
            void OnPowerUp2(InputAction.CallbackContext context);
            void OnPowerUp3(InputAction.CallbackContext context);
            void OnPowerUp4(InputAction.CallbackContext context);
        }
    }
}
