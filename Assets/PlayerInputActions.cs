//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ca29533b-ac78-4638-b3f0-ae13b518ae0a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4a1fb548-ffa8-41db-acf8-f1f27f60a8a9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3c235bd0-de16-48dd-a0ec-85e32e8e72e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a5b62405-4b69-4932-82bd-e368c37b2491"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""c74fa85b-f6a9-46a9-846a-129998f81b51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dashing"",
                    ""type"": ""Button"",
                    ""id"": ""ad7c1403-c45f-4d07-a115-27a4ab0e2384"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Talk"",
                    ""type"": ""Button"",
                    ""id"": ""3f2a37b3-571d-473d-8582-fd2eccd52961"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""29c9b567-9149-49fb-a704-abc30868c368"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Spell"",
                    ""type"": ""Button"",
                    ""id"": ""e88be524-5789-4265-834a-15ce9470231c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Bag"",
                    ""type"": ""Button"",
                    ""id"": ""a214698c-efa3-4d60-bc96-cf8544ab36c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Treasure"",
                    ""type"": ""Button"",
                    ""id"": ""0ca2f667-c17e-4138-a80b-a60ccf56d530"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""ee37ea43-9585-4212-a1eb-cec425511ba7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MenuOpenClose"",
                    ""type"": ""Button"",
                    ""id"": ""0c3ab12f-569d-4dd5-bfa4-d155d0d22e10"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""57311eb1-71a2-4858-b385-ee4fdade2490"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""797d571e-0113-4d72-9531-7f21091c7440"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d3d083c7-ec12-4cb8-ac94-b5973d6d3ffd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""84af9511-d393-457d-97d8-ecf98c5f8688"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45b66599-dd94-4af8-93a2-8df7ce02640e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81788a5c-42b1-4f9e-a4b9-3cf2cec29757"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Hold(duration=1.401298E-45,pressPoint=1.401298E-45)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""271e194e-4a0b-4fb8-a04a-dd12768cc73c"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dashing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6a87795-331a-4282-a92d-c67fe2b3589c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Talk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4695e8b8-250e-4329-ac2f-97310b5cf36d"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf46f5cb-2e0a-4319-b733-37c7f05c3049"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7e00a42-a297-44b8-a84b-ffee7c4abdaa"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f7e945e-d95d-4d31-81a2-248972af836e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Treasure"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9d4756a-6883-4b78-a066-781ff292ac24"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5eab2af6-0f1d-4613-9797-3218e5bd8746"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuOpenClose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_Dashing = m_Player.FindAction("Dashing", throwIfNotFound: true);
        m_Player_Talk = m_Player.FindAction("Talk", throwIfNotFound: true);
        m_Player_Guard = m_Player.FindAction("Guard", throwIfNotFound: true);
        m_Player_Spell = m_Player.FindAction("Spell", throwIfNotFound: true);
        m_Player_Bag = m_Player.FindAction("Bag", throwIfNotFound: true);
        m_Player_Treasure = m_Player.FindAction("Treasure", throwIfNotFound: true);
        m_Player_Save = m_Player.FindAction("Save", throwIfNotFound: true);
        m_Player_MenuOpenClose = m_Player.FindAction("MenuOpenClose", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_Dashing;
    private readonly InputAction m_Player_Talk;
    private readonly InputAction m_Player_Guard;
    private readonly InputAction m_Player_Spell;
    private readonly InputAction m_Player_Bag;
    private readonly InputAction m_Player_Treasure;
    private readonly InputAction m_Player_Save;
    private readonly InputAction m_Player_MenuOpenClose;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @Dashing => m_Wrapper.m_Player_Dashing;
        public InputAction @Talk => m_Wrapper.m_Player_Talk;
        public InputAction @Guard => m_Wrapper.m_Player_Guard;
        public InputAction @Spell => m_Wrapper.m_Player_Spell;
        public InputAction @Bag => m_Wrapper.m_Player_Bag;
        public InputAction @Treasure => m_Wrapper.m_Player_Treasure;
        public InputAction @Save => m_Wrapper.m_Player_Save;
        public InputAction @MenuOpenClose => m_Wrapper.m_Player_MenuOpenClose;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
            @Dashing.started += instance.OnDashing;
            @Dashing.performed += instance.OnDashing;
            @Dashing.canceled += instance.OnDashing;
            @Talk.started += instance.OnTalk;
            @Talk.performed += instance.OnTalk;
            @Talk.canceled += instance.OnTalk;
            @Guard.started += instance.OnGuard;
            @Guard.performed += instance.OnGuard;
            @Guard.canceled += instance.OnGuard;
            @Spell.started += instance.OnSpell;
            @Spell.performed += instance.OnSpell;
            @Spell.canceled += instance.OnSpell;
            @Bag.started += instance.OnBag;
            @Bag.performed += instance.OnBag;
            @Bag.canceled += instance.OnBag;
            @Treasure.started += instance.OnTreasure;
            @Treasure.performed += instance.OnTreasure;
            @Treasure.canceled += instance.OnTreasure;
            @Save.started += instance.OnSave;
            @Save.performed += instance.OnSave;
            @Save.canceled += instance.OnSave;
            @MenuOpenClose.started += instance.OnMenuOpenClose;
            @MenuOpenClose.performed += instance.OnMenuOpenClose;
            @MenuOpenClose.canceled += instance.OnMenuOpenClose;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
            @Dashing.started -= instance.OnDashing;
            @Dashing.performed -= instance.OnDashing;
            @Dashing.canceled -= instance.OnDashing;
            @Talk.started -= instance.OnTalk;
            @Talk.performed -= instance.OnTalk;
            @Talk.canceled -= instance.OnTalk;
            @Guard.started -= instance.OnGuard;
            @Guard.performed -= instance.OnGuard;
            @Guard.canceled -= instance.OnGuard;
            @Spell.started -= instance.OnSpell;
            @Spell.performed -= instance.OnSpell;
            @Spell.canceled -= instance.OnSpell;
            @Bag.started -= instance.OnBag;
            @Bag.performed -= instance.OnBag;
            @Bag.canceled -= instance.OnBag;
            @Treasure.started -= instance.OnTreasure;
            @Treasure.performed -= instance.OnTreasure;
            @Treasure.canceled -= instance.OnTreasure;
            @Save.started -= instance.OnSave;
            @Save.performed -= instance.OnSave;
            @Save.canceled -= instance.OnSave;
            @MenuOpenClose.started -= instance.OnMenuOpenClose;
            @MenuOpenClose.performed -= instance.OnMenuOpenClose;
            @MenuOpenClose.canceled -= instance.OnMenuOpenClose;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnDashing(InputAction.CallbackContext context);
        void OnTalk(InputAction.CallbackContext context);
        void OnGuard(InputAction.CallbackContext context);
        void OnSpell(InputAction.CallbackContext context);
        void OnBag(InputAction.CallbackContext context);
        void OnTreasure(InputAction.CallbackContext context);
        void OnSave(InputAction.CallbackContext context);
        void OnMenuOpenClose(InputAction.CallbackContext context);
    }
}
