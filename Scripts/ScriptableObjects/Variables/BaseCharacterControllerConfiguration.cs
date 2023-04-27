using UnityEngine;

[CreateAssetMenu(fileName = "Characters Configurations", menuName = "Base Character Controller/Create New Controller Configurations", order = 1)]
public class BaseCharacterControllerConfiguration : ScriptableObject
{
    private Rigidbody2D _rigidbody2D;

    private Vector2 _movementDirection = Vector2.zero;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _combatStanceSpeed;
    private float _currentMovementSpeed;

    private bool _isCombatStance;
    private bool _isSprinting;
    private bool _isDashing;
    private bool _isMoving;


    public Rigidbody2D RB2D { get => _rigidbody2D; set => _rigidbody2D = value; }

    public Vector2 MovementDirection { get => _movementDirection; set => _movementDirection = value; }

    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    public float SprintSpeed { get => _sprintSpeed; set => _sprintSpeed = value; }
    public float CombatStanceSpeed { get => _combatStanceSpeed; set => _combatStanceSpeed = value; }
    public float CurrentMovementSpeed { get => _currentMovementSpeed; set => _currentMovementSpeed = value; }

    public bool IsCombatStance { get => _isCombatStance; set => _isCombatStance = value; }
    public bool IsSprinting { get => _isSprinting; set => _isSprinting = value; }
    public bool IsDashing { get => _isDashing; set => _isDashing = value; }
    public bool IsMoving { get => _isMoving; set => _isMoving = value; }
}