using UnityEngine;

public class ModuleLookTowards : MonoBehaviour
{
    public BaseCharacterControllerConfiguration characterConfigs;

    float rotationSpeed = 45;
    Vector3 currentEulerAngles;
    Quaternion currentRotation;

    public void Update()
    {
        LookTowardsMouse();
    }

    public void LookTowardsMouse()
    {
        Vector3 ObjPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 dir = Input.mousePosition - ObjPos;

        float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;// * Mathf.Rad2Deg;

        characterConfigs.RB2D.MoveRotation(-rotZ);
    }

    public void LookTowardsDirection(Vector3 lookDirection)
    {
        // FINISH this method.
    }
}