using UnityEngine;
using UnityEngine.AI;

[ RequireComponent( typeof ( NavMeshAgent ) ) ]
public class BaseMovement : MonoBehaviour
{
    private BaseMovement _baseMovement;
    private BaseInteractions _baseInteractions;
    private CharacterControllerBase _characterControllerBase;

    [HideInInspector] public Ray ray;
    [HideInInspector] public RaycastHit hit;

    public void SetCharacterController ( CharacterControllerBase controller )
    {
        _characterControllerBase = controller;
    }

    public void SetMovementController ( BaseMovement controller )
    {
        _baseMovement.SetMovementController ( controller );
    }

    public void Start()
    {
        _baseInteractions = GetComponent <BaseInteractions>();
        _baseInteractions?.SetMovementController(this);
        Debug.Log(_baseInteractions);
    }

    public void MoveToPosition (Vector3 m_point)
    {
        if ( _characterControllerBase != null )
        {
            _characterControllerBase.aiAgent.SetDestination ( m_point );
        }
        Debug.LogWarning("[-] Null controller at BaseMovement.");
    }

    public bool RaycastToPosition(Vector3 position, out RaycastHit hitInfo, float maxDistance, LayerMask layerMask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hitInfo, maxDistance, layerMask);
    }
}