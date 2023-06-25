using UnityEngine;

/// <summary>
/// Basic Platform Script - dynamicly controls it's movement within it's List of targets
/// and index changes everytime it achieves the goal.
/// attach this script to your platform and set up the "platformSpeed" field for your own needs
/// platforms moves horizontaly and verticaly chasing the target ( your points )
/// </summary>

public class ModulePlatform : MonoBehaviour
{
    // a list of target positions, Transform objects. These target positions should be assigned in the Unity inspector by adding empty GameObjects to the list.
    [SerializeField] private List<Transform> targets = new List<Transform>();

    // holds the current target position that the platform is moving towards.
    [SerializeField] private Transform currentTarget;

    // you can use this public field for your own needs in case you want to detect the change of target.
    [HideInInspector] public bool targetChanged;

    [SerializeField] private float platformSpeed;

    private void Update()
    {
        // Check whether "currentTarget" is null, if true in assigns it to first item in the list.
        currentTarget ??= targets[0];

        // Check distance to see if we are close to the target.
        float distance = Vector2.Distance(transform.position, currentTarget.position);

        // If we did not achieved our goal yet, we will move our platform.
        if (distance > 0.2F)
        {
            targetChanged = false;

            Vector2 directionToTarget = currentTarget.position - transform.position;
            
            Vector2 movementInDirection = directionToTarget.normalized * speed * Time.deltaTime;
            
            transform.Translate(movementInDirection);
            
            return;
        }

        ChangeTarget();
    }

    private void ChangeTarget()
    {
        int currentIndex = targets.IndexOf(currentTarget);

        // - 1 because list starts from 1 to 'eternity' and index starts from 0 to 'eternity', so we want to arrange them properly to avoid errors.
        if (currentIndex == targets.Count - 1)
        {
            targetChanged = true;

            currentTarget = targets[0];
            
            return;
        }

        currentTarget = targets[currentIndex + 1];
        
        targetChanged = true;
    }
}