using UnityEngine;
using UnityEngine.InputSystem;

public class ModuleCombatStance : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;

    private InputBindingsController _input = null;

    private void OnEnable()
    {
        _input.Enable();
        _input.Character.CombatStance.performed += OnCombatStancePerformed;
        _input.Character.CombatStance.canceled += OnCombatStanceCanceled;
    }

    private void OnDisable()
    {
        _input.Disable();
        _input.Character.CombatStance.performed -= OnCombatStancePerformed;
        _input.Character.CombatStance.canceled -= OnCombatStanceCanceled;
    }

    private void Awake()
    {
        _input = new InputBindingsController();
    }

    private void OnCombatStancePerformed(InputAction.CallbackContext value)
    {
        characterConfigs.IsCombatStance = value.ReadValueAsButton();
    }

    private void OnCombatStanceCanceled(InputAction.CallbackContext value)
    {
        characterConfigs.IsCombatStance = value.ReadValueAsButton();
    }
}