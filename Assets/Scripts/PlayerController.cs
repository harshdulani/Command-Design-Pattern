using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float XPos => transform.position.x;
    public float ZPos => transform.position.z;
    
    public void MoveTo(float x, float z)
    {
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
