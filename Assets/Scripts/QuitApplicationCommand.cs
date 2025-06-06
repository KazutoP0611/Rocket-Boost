using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplicationCommand : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            //Debug.LogWarning("Hello");
            Application.Quit();
        }
    }
}
