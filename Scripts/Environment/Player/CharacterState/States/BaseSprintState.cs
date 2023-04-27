using UnityEngine;

public class BaseSprintState : BaseCharacterStateAbstract
{
    public BaseCharacterControllerConfiguration characterConfigs;

    public BaseSprintState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(BaseCharacterStateManager character)
    {
        character.characterConfigs.CurrentMovementSpeed = characterConfigs.SprintSpeed;
    }

    public override void UpdateState(BaseCharacterStateManager character)
    {
        if (!characterConfigs.IsSprinting && characterConfigs.IsCombatStance)
        {
            // NOTE : Decrease stamina while this is active state.
            character.SwitchState(character.CombatStanceState);
        }

        if (!characterConfigs.IsSprinting && !characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.WalkState);
        }

        if (!characterConfigs.IsMoving && !characterConfigs.IsCombatStance && !characterConfigs.IsSprinting)
        {
            character.SwitchState(character.IdleState);
        }

        if (characterConfigs.IsDashing)
        {
            character.SwitchState(character.DashState);
        }
    }

    public override void ExitState(BaseCharacterStateManager character)
    {
        //characterConfigs.IsSprinting = false;
        character.characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}