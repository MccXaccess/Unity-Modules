using UnityEngine;

public class ModuleRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; 
    
    [Tooltip("If boolean set to false, it will rotate right")] public bool rotateLeft;

        private void Update()
    {
        float rotationDirection = rotateLeft ? -1f : 1f;
        transform.Rotate(Vector3.forward * rotationDirection * rotationSpeed * Time.deltaTime);
    }
}