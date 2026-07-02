using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public static PlayerInputHandler Instance;

    private InputSystem_Actions controls;

    public Vector2 MoveInput { get; private set; }

    public Vector2 LookInput { get; private set; }

    public bool JumpPressed { get; private set; }

    public bool SprintPressed { get; private set; }

    public bool InteractPressed { get; private set; }

    public bool PausePressed { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        controls = new InputSystem_Actions();
        controls.Player.SetCallbacks(this);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void LateUpdate()
    {
        JumpPressed = false;
        InteractPressed = false;
        PausePressed = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            JumpPressed = true;
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        SprintPressed = context.ReadValueAsButton();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
            return;

            InteractPressed = true;
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PausePressed = true;
            Debug.Log("Pause Ditekan");
        }
    }

    // Belum digunakan
    public void OnAttack(InputAction.CallbackContext context) { }
    public void OnCrouch(InputAction.CallbackContext context) { }
    public void OnPrevious(InputAction.CallbackContext context) { }
    public void OnNext(InputAction.CallbackContext context) { }
}