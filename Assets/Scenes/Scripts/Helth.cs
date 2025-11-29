using UnityEngine;

public class Helth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

    }
    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
