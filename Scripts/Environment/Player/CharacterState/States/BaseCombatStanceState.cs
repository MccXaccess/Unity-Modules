using UnityEngine;

public class BaseCombatStanceState : BaseCharacterStateAbstract
{
    public BaseCharacterControllerConfiguration characterConfigs;

    public BaseCombatStanceState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(BaseCharacterStateManager character)
    {
        character.characterConfigs.CurrentMovementSpeed = characterConfigs.CombatStanceSpeed;
    }

    public override void UpdateState(BaseCharacterStateManager character)
    {
        if (characterConfigs.IsSprinting && !characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.SprintState);
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
        // do the combat stance value to false
        // NOTE : you should really make methods to set values to false or true without direct reference SET
        //characterConfigs.IsCombatStance = false;
        character.characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}