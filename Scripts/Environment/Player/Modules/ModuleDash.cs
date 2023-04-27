using UnityEngine;
using UnityEngine.InputSystem;

public class ModuleDash : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;

    private InputBindingsController _input = null;

    private void OnEnable()
    {
        _input.Enable();
        _input.Character.Dash.performed += OnDashPerformed;
        _input.Character.Dash.canceled += OnDashCanceled;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Character.Dash.performed -= OnDashPerformed;
        _input.Character.Dash.canceled -= OnDashCanceled;
    }

    private void Awake()
    {
        _input = new InputBindingsController();
    }

    private void OnDashPerformed(InputAction.CallbackContext value)
    {
        characterConfigs.IsDashing = value.ReadValueAsButton();
    }

    private void OnDashCanceled(InputAction.CallbackContext value)
    {
        characterConfigs.IsDashing = value.ReadValueAsButton();
    }
}