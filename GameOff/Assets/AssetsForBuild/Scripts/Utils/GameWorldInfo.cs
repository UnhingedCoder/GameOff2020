using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWorldInfo : MonoBehaviour
{
    [Header("Player")]
    public Text xVelDisplay;
    public Text yVelDisplay;
    public Text zVelDisplay;
    public Toggle groundedDisplay;

    public CharacterController controller;

    [Header("Time")]
    public Text dayDisplay;
    public Text timeDisplay;

    private void Update()
    {
        xVelDisplay.text = "X: " + Round(controller.velocity.x, 2);
        yVelDisplay.text = "Y: " + Round(controller.velocity.y, 2);
        zVelDisplay.text = "Z: " + Round(controller.velocity.z, 2);

        groundedDisplay.isOn = controller.isGrounded;

        timeDisplay.text = "TIME: " + Round(MoonTime.Instance.CurrentTime, 2);
        dayDisplay.text = "DAY: " + Round(MoonTime.Instance.CurrentDay, 2);
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
}
