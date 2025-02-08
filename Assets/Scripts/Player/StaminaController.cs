using InfimaGames.LowPolyShooterPack;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    private CharacterBehaviour playerCharacter;
    private PlayerManager playerManager;

    protected void Awake()
    {
        playerCharacter = ServiceLocator.Current.Get<IGameModeService>().GetPlayerCharacter();
        playerManager = FindFirstObjectByType<PlayerManager>();
    }

    void Update()
    {
        StaminaDepletesByRunning();
        StaminaRegenerates();
    }

    private void StaminaDepletesByRunning() {

        if (playerCharacter.IsRunning() && playerManager.getStamina()>0)
        {
            playerManager.LessenStamina(0.5f);
        }
    }
    private void StaminaRegenerates() {

        if (!playerCharacter.IsRunning() && playerManager.getStamina()<100) {
            playerManager.BoostStamina(0.3f);
        
        }
    }
}
