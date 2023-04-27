using UnityEngine;

public class BaseCharacterStateManager : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;
    
    private BaseCharacterStateAbstract currentState;

    public BaseIdleState IdleState;
    public BaseWalkState WalkState;
    public BaseDashState DashState;
    public BaseSprintState SprintState;
    public BaseCombatStanceState CombatStanceState;
    
    private void Start()
    {
        IdleState = new BaseIdleState(characterConfigs);
        WalkState = new BaseWalkState(characterConfigs);
        DashState = new BaseDashState(characterConfigs);
        SprintState = new BaseSprintState(characterConfigs);
        CombatStanceState = new BaseCombatStanceState(characterConfigs);
        
        currentState = IdleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    // takes the current bool state to set that to false
    public void SwitchState(BaseCharacterStateAbstract state)
    {
        state.ExitState(this);

        currentState = state;
        
        state.EnterState(this);
    }
}