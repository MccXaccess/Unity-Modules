using UnityEngine;
using UnityEngine.InputSystem;

public class ModuleMovement : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;

    private InputBindingsController _input = null;


    private void OnEnable()
    {
        _input.Enable();
        _input.Character.Movement.performed += OnMovementPerformed;
        _input.Character.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Character.Movement.performed -= OnMovementPerformed;
        _input.Character.Movement.canceled -= OnMovementCanceled;
    }

    private void Awake()
    {
        _input = new InputBindingsController();
    }

    private void FixedUpdate()
    {
        characterConfigs.RB2D.velocity = characterConfigs.MovementDirection * characterConfigs.CurrentMovementSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        characterConfigs.MovementDirection = value.ReadValue<Vector2>();
        characterConfigs.IsMoving = true;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        characterConfigs.MovementDirection = Vector2.zero;
        characterConfigs.IsMoving = false;
    }
}