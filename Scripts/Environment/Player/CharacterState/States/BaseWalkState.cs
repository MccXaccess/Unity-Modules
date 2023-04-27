using UnityEngine;

public class BaseWalkState : BaseCharacterStateAbstract
{
    private BaseCharacterControllerConfiguration characterConfigs;

    public BaseWalkState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(BaseCharacterStateManager character)
    {
        character.characterConfigs.CurrentMovementSpeed = characterConfigs.WalkSpeed;
    }

    public override void UpdateState(BaseCharacterStateManager character)
    {
        if (characterConfigs.IsSprinting && !characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.SprintState);
        }

        if (!characterConfigs.IsSprinting && characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.CombatStanceState);
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
        character.characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}