using TMPro;
using UnityEngine;

public class CollectedObjectives : MonoBehaviour
{
    public PlayerManager playerManager;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        int collected = playerManager.ObjectivesCollected;

        text.text = $"Collected: {collected} / 4";
    }
}
