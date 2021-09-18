using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void MoveLeft()
    {
        transform.position += Vector3.left;
    }

    public void MoveRight()
    {
        transform.position += Vector3.right;
    }

    public void MoveForward()
    {
        transform.position += Vector3.forward;
    }

    public void MoveBack()
    {
        transform.position += Vector3.back;
    }
}
