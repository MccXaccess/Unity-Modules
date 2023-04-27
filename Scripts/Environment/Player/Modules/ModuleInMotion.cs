using UnityEngine;

public class ModuleInMotion : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;

    private float _timerMaximum = 0.3f;
    private float _timerCurrent = 0.0f;

    private void Update()
    {
        CheckMotion();
    }

    private void CheckMotion()
    {
        if(characterConfigs.MovementDirection == Vector2.zero)
        {
            _timerCurrent -= Time.deltaTime;

            if (_timerCurrent < 0.0f)
            {
                characterConfigs.IsMoving = false;
            }
        }
        else { _timerCurrent = _timerMaximum; characterConfigs.IsMoving = true; }
    }
}