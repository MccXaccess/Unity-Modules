using UnityEngine;

public class BaseSprinting : MonoBehaviour
{
    private CharacterControllerBase _characterControllerBase;

    public void SetCharacterController(CharacterControllerBase controller)
    {
        _characterControllerBase = controller;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    public void UpdateMovement()
    {
        SetAgentSpeed();
        SetRigidbodyVelocity();
        UpdateStamina();
        RegenerateStamina();
    }

    private void SetAgentSpeed()
    {
        _characterControllerBase.aiAgent.speed = _characterControllerBase.isSprinting ? _characterControllerBase.movementSprintingSpeed : _characterControllerBase.movementWalkingSpeed;
    }

    private void SetRigidbodyVelocity()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * _characterControllerBase.aiAgent.speed;
    }

    private void UpdateStamina()
    {
        if (_characterControllerBase.isSprinting && _characterControllerBase.sprintingCurrentStamina > 0f)
        {
            DecreaseStamina();
        }
    }

    private void DecreaseStamina()
    {
        _characterControllerBase.sprintingCurrentStamina -= _characterControllerBase.sprintingStaminaDecreaseRate * Time.deltaTime;

        if (_characterControllerBase.sprintingCurrentStamina < 0f)
        {
            _characterControllerBase.sprintingCurrentStamina = 0f;
            _characterControllerBase.isSprinting = false;
        }
    }

    public void RegenerateStamina ()
    {
        if (!_characterControllerBase.isSprinting && _characterControllerBase.sprintingCurrentStamina < _characterControllerBase.sprintingMaxStamina)
        {
            _characterControllerBase.sprintingCurrentStamina += _characterControllerBase.sprintingStaminaIncreaseRate * Time.deltaTime;
        }
    }
}
