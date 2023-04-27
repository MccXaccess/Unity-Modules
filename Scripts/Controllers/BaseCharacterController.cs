using Debug = UnityEngine.Debug;
using UnityEngine;

public class BaseCharacterController : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;

    private Rigidbody2D _rb2d = null;

    private void OnEnable()
    {
        Debug.Log("Instance of " + this.gameObject.name + " has been enabled!");
    }

    private void OnDisable()
    {
        Debug.Log("Instance of " + this.gameObject.name + " has been disabled!");
    }

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        characterConfigs.RB2D = _rb2d;
    }
}