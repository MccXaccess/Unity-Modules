using UnityEngine;

public class BaseIdleState : BaseCharacterStateAbstract
{
    private BaseCharacterControllerConfiguration characterConfigs;

    public BaseIdleState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(BaseCharacterStateManager character)
    {
        character.characterConfigs.CurrentMovementSpeed = 0.0f;
    }

    public override void UpdateState(BaseCharacterStateManager character)
    {
        if (characterConfigs.IsMoving)
        {
            character.SwitchState(character.WalkState);
        }

        if (characterConfigs.IsSprinting)
        {
            character.SwitchState(character.SprintState);
        }

        if (characterConfigs.IsCombatStance && !characterConfigs.IsSprinting)
        {
            character.SwitchState(character.CombatStanceState);
        }

        if (characterConfigs.IsDashing)
        {
            character.SwitchState(character.DashState);
        }
    }

    public override void ExitState(BaseCharacterStateManager character)
    {
        // NOTE : make this reference to Movement Scriptable Object so it wouldn't be static?
        character.characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}