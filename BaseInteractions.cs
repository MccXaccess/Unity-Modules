using UnityEngine;

public class BaseInteractions : MonoBehaviour
{
    private CharacterControllerBase _characterControllerBase;
    private BaseMovement _baseMovement;

    public void SetCharacterController ( CharacterControllerBase controller )
    {
        _characterControllerBase = controller;
    }

    public void SetMovementController ( BaseMovement controller )
    {
        _baseMovement = controller;
    }

    public void HandleLeftClick ()
    {
        RaycastHit hit;

        if ( _baseMovement.RaycastToPosition( Input.mousePosition, out hit, 100, _characterControllerBase.movementMask ) )
        {
            _baseMovement.MoveToPosition ( hit.point );
        }

        //Debug.Log("We hit" + hit.collider.name + " " + hit.point);

    }

    // ON DEVELOPMENT STATE: 
    public void HandleRightClick ()
    {
        Ray ray = _characterControllerBase.cameraObject.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if ( Physics.Raycast ( _baseMovement.ray, out _baseMovement.hit, 100 ) )
        {

        }
    }
}