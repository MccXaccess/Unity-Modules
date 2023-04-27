using UnityEngine;
using UnityEngine.InputSystem;

// MAKE EVERY ACTION INDEPENDENT CONTROLLS OR REFERENCE TO THIS SCRIPT?
// NOTE: ON DEVELOPMENT.
[CreateAssetMenu(fileName = "Inputs Configurations", menuName = "Base Input Controller/Create New Controller Configurations", order = 1)]
public class BaseInputControllerConfiguration : ScriptableObject
{
    [SerializeField] private KeyCode _controlsDash;
    [SerializeField] private KeyCode _controlsSprint;
    [SerializeField] private KeyCode _controlsCombatStance;

    private InputBindingsController _input = null;


    public KeyCode ControlsDash { get => _controlsDash; set => _controlsDash = value; }
    public KeyCode ControlsSprint { get => _controlsSprint; set => _controlsDash = value; }
    public KeyCode ControlsCombatStance { get => _controlsCombatStance; set => _controlsCombatStance = value; }

    public InputBindingsController InputController { get => _input; private set => _input = value;}

    private void Awake()
    {
        InputController =  new InputBindingsController();
    }
}