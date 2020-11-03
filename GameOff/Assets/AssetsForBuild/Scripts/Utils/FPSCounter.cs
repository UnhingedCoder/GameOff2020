using UnityEngine;
using UnityEngine.UI;


public class FPSCounter : MonoBehaviour
{
    public Text fpsDisplay;
    public Text averageFPSDisplay;
    public Text minFPSDisplay, maxFPSDisplay;

    int framesPassed = 0;

    float fpsTotal = 0f;
    float minFPS = Mathf.Infinity;
    float maxFPS = 0f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        float fps = 1 / Time.unscaledDeltaTime;

        fpsDisplay.text = "FPS: " + Mathf.RoundToInt(fps);

        fpsTotal += fps;
        framesPassed++;

        averageFPSDisplay.text = "Avg: " + Mathf.RoundToInt(fpsTotal / framesPassed);

        if (fps > maxFPS && framesPassed > 10)
        {
            maxFPS = fps;
            maxFPSDisplay.text = "Max: " + Mathf.RoundToInt(maxFPS);
        }
        if (fps < minFPS && framesPassed > 10)
        {
            minFPS = fps;
            minFPSDisplay.text = "Min: " + Mathf.RoundToInt(minFPS);
        }
    }
}