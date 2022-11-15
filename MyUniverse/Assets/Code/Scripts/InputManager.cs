using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float Horizontal { get; private set; }
    public static float Vertical { get; private set; }

    [SerializeField] private FloatingJoystick floatingJoystick;

    void Update()
    {
        // Horizontal = Input.GetAxis("Horizontal");
        // Vertical = Input.GetAxis("Vertical");

        Horizontal = floatingJoystick.Horizontal;
        Vertical = floatingJoystick.Vertical;
    }
}