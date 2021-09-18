using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Button p1, p2;

    private void Start()
    {
        ControlP1();
    }

    public void ControlP1()
    {
        InputHandler.playerToControl = 1;
        p1.interactable = false;
        p2.interactable = true;
    }
    
    public void ControlP2()
    {
        InputHandler.playerToControl = 2;
        p1.interactable = true;
        p2.interactable = false;
    }
}
