using UnityEngine;

public class HelthAn : MonoBehaviour
{
    public int maxHealthAn;
    private int currentHealthAn;
    void Start()
    {
        currentHealthAn = maxHealthAn;
    }
    public void TakeDamage(int damageAn)
    {
        currentHealthAn -= damageAn;

    }
    public void Heal(int heal)
    {
        currentHealthAn += heal;
        if (currentHealthAn > maxHealthAn)
            currentHealthAn = maxHealthAn;
    }
    public int GetCurrentHealth()
    {
        return currentHealthAn;
    }
}
