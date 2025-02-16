using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Slider healthSlider;
    public Slider staminaSlider;

    public int MaxHealth = 100;
    public float MaxStamina = 100;

    private int Health;
    private float Stamina;
    public int ObjectivesCollected { get; private set; }

    private GameManager gameManager;
    private PlayerSounds playerSounds;
    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        playerSounds = GetComponent<PlayerSounds>();

        Health = MaxHealth;
        healthSlider.maxValue = MaxHealth;
        healthSlider.value = Health;

        Stamina = MaxStamina;
        staminaSlider.maxValue = MaxStamina;
        staminaSlider.value = Stamina;
    }

    public void collectObjective()
    {
        ObjectivesCollected++;

        if (ObjectivesCollected == 4)
            print("Good game");
    }

    public float getStamina()
    {
        return Stamina;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            TakeDamage(20);

        healthSlider.value = Health;
        staminaSlider.value = Stamina;
    }

    public void LessenStamina(float amount)
    {
        Stamina -= amount;
    }
    public void BoostStamina(float amount)
    {
        Stamina += amount;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        playerSounds.PlayHurtSound();

        if (Health <= 0)
            gameManager.GameOver();
    }
    public void Heal(int amount)
    {
        if (Health == 100) { 
            print("Cant heal, max health");
            return;
        }

        if (Health + amount > 100)
            Health = 100;
        else
            Health += amount;
    }

}
