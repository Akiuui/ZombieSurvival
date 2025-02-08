using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText; // Reference to the UI Text component
    private float timeElapsed = 0.0f;
    private int frameCount = 0;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        frameCount++;

        if (timeElapsed >= 1.0f)
        {
            int fps = Mathf.RoundToInt(frameCount / timeElapsed);
            fpsText.text = $"FPS: {fps}";
            timeElapsed = 0.0f;
            frameCount = 0;
        }
    }
}
