using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public Material skyboxDay;
    public Material skyboxNight;

    public float transitionSpeed = 1f;
    private GameClock gameClock;

    private void Start()
    {
        gameClock = GetComponent<GameClock>();
    }

    private void Update()
    {
        float time = gameClock.currentHours + (gameClock.currentMinutes / 60f);

        float t = Mathf.InverseLerp(6f, 18f, time);

        RenderSettings.skybox.Lerp(skyboxNight, skyboxDay, t);
        DynamicGI.UpdateEnvironment(); // Updates lighting

    }
}
