public abstract class BaseCharacterStateAbstract
{
    // NOTE : Physics Update State.

    public abstract void EnterState(BaseCharacterStateManager character);

    public abstract void UpdateState(BaseCharacterStateManager character);

    public abstract void ExitState(BaseCharacterStateManager character);
}