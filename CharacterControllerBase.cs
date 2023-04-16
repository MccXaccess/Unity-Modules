using UnityEngine;
using UnityEngine.AI;

/* TODO:
 * variable && function access from Interfaces , Get/Set-ters
 * make IDamageable, IAtackeable.
 * 
 */
public interface ICharacterController
{
    bool isSprinting { get; }
    float sprintingCurrentStamina { get; set; }
    float sprintingMaxStamina { get; }
    float sprintingStaminaIncreaseRate { get; }
}

[RequireComponent(typeof(BaseMovement))]
public class CharacterControllerBase : MonoBehaviour
{
    private CharacterControllerBase _characterControllerBase;

    public LayerMask movementMask;

    public float movementWalkingSpeed = 5f;
    public float movementSprintingSpeed = 10f;

    public float sprintingCurrentStamina = 100f;
    public float sprintingStaminaDecreaseRate = 10f;
    public float sprintingStaminaIncreaseRate = 6f;
    public float sprintingMaxStamina = 100f;

    [HideInInspector] public bool isSprinting = false;

    [HideInInspector] public Camera cameraObject = Camera.main;
    [HideInInspector] public NavMeshAgent aiAgent;
    [HideInInspector] public Rigidbody _rigidbody;


    // Instances reference
    private BaseMovement _baseMovement;
    private CircleRadius _circleRadius;
    private BaseInteractions _baseInteractions;
    private BaseSprinting _baseSprinting;

    public void SetCharacterController(CharacterControllerBase controller)
    {
        _characterControllerBase.SetCharacterController(controller);
    }

    private void Start ()
    {
        _baseInteractions = GetComponent<BaseInteractions>();
        _baseMovement = GetComponent<BaseMovement>();
        _circleRadius = GetComponent<CircleRadius>();
        _baseSprinting = GetComponent<BaseSprinting>();

        aiAgent = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();

        // allowing groups of instances to allow use our controllers
        _baseMovement.SetCharacterController(this);
        _baseInteractions.SetCharacterController(this);
        _baseSprinting.SetCharacterController(this);

        // make camera accessible from camera script
        //cameraObject = Camera.main;
    }

    private void Update ()
    {
        _circleRadius.InsideRadius ();

        if ( Input.GetMouseButtonDown ( 0 ) )
        {
            _baseInteractions.HandleLeftClick ();
        }

        if ( Input.GetMouseButtonDown ( 1 ) )
        {
            _baseInteractions.HandleRightClick ();
        }

        if ( Input.GetKeyDown ( KeyCode.LeftShift ) )
        {
            isSprinting = true;
        }

        else if ( Input.GetKeyUp ( KeyCode.LeftShift ) )
        {
            isSprinting = false;
        }

    }
}
