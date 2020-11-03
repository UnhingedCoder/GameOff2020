using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWorldInfo : MonoBehaviour
{
    public Text xVelDisplay;
    public Text yVelDisplay;
    public Text zVelDisplay;
    public Toggle groundedDisplay;

    public CharacterController controller;

    private void Update()
    {
        xVelDisplay.text = "Vel X: " + Round(controller.velocity.x, 2);
        yVelDisplay.text = "Vel Y: " + Round(controller.velocity.y, 2);
        zVelDisplay.text = "Vel Z: " + Round(controller.velocity.z, 2);

        groundedDisplay.isOn = controller.isGrounded;
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
}
