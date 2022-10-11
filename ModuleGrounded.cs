using UnityEngine;

/* Info: Checks the "GameObject" on what "layer" it is standing on */

/* Explanation: taking point A is left-top corner and point B right-bottom corner. */
/*              Imagine this as a box and what is inside of it is area that's gonna be checked. */
/*              IF that Unity's Physics Method "OverlapArea" detected our certain layer for example 'ground' */
/*              makes '_grounded' variable true. */

public class ModuleGrounded : MonoBehaviour
{

    public Transform _target;

    public bool _grounded;

    [Header("Area to Check for:")] [Space(10)]
    public Vector3 _pointA;
    public Vector3 _pointB;
    [Header("LayerMask to Check Particular Layer:")] [Space(10)]
    public LayerMask _layerMask;

    private float _maxDepth;
    private float _minDepth;

    public void Awake()
    {
        _target = GetComponent<Transform>();
    }

    public void isGrounded()
    {
        var check = Physics2D.OverlapArea(_target.position + _pointA, _target.position + _pointB, _layerMask, _minDepth = -Mathf.Infinity, _maxDepth = Mathf.Infinity);
        if (check != null) _grounded = true; else _grounded = false;
    }

    public void Update()
    {
        isGrounded();
        // module draw gizmos surrounding the area.
    }
}