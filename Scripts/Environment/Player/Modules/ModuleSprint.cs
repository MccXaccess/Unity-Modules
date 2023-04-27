using UnityEngine;
using UnityEngine.InputSystem;

public class ModuleSprint : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;

    private InputBindingsController _input = null;

    private void OnEnable()
    {
        _input.Enable();
        _input.Character.Sprint.performed += OnSprintPerformed;
        _input.Character.Sprint.canceled += OnSprintCanceled;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Character.Sprint.performed -= OnSprintPerformed;
        _input.Character.Sprint.canceled -= OnSprintCanceled;
    }

    private void Awake()
    {
        _input = new InputBindingsController();
    }

    private void OnSprintPerformed(InputAction.CallbackContext value)
    {
        characterConfigs.IsSprinting = value.ReadValueAsButton();
    }

    private void OnSprintCanceled(InputAction.CallbackContext value)
    {
        characterConfigs.IsSprinting = value.ReadValueAsButton();
    }
}