using UnityEngine;

public class RotateBelt : MonoBehaviour
{
    public Vector3 rotationSpeed;
    
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
