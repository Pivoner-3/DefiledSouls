using UnityEngine;
using UnityEngine.UI;
public class HPDamagePlayer : MonoBehaviour
{
    public HBar HPbar;
    public Transform startPosition;
    private bool isDead;
    public HPDamageEnemy HpdamEn;

    public float maxHealth = 100f;
    public float currentHealth;
    public float damagePlayer = 10f;
    public bool attackbool = false;
    public KeyCode attack = KeyCode.R;
    
    void Start()
    {
        if (HPbar == null)
        {
            GameObject healtDam = GameObject.Find("HBar");
            if (healtDam != null)
            {
                HPbar = healtDam.GetComponent<HBar>();
            }
        }
        currentHealth = maxHealth;
        isDead = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(attack))
        {
            attackbool = true;
            Attack();
        }
        if (isDead)
        {
            // Возвращаем игрока на стартовую позицию
            transform.position = startPosition.position;
            // Восстанавливаем здоровье
            currentHealth = maxHealth;
            // Снимаем флаг смерти
            isDead = false;
        }
    }

    void Attack()
    {
        if (!attackbool) return;

        // Ищем ближайшего врага
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            GameObject closestEnemy = enemies[0];
            float closestDistance = Vector2.Distance(transform.position, closestEnemy.transform.position);

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            // Если враг достаточно близко
            if (closestDistance < 3f)
            {
                HPDamageEnemy enemyScript = closestEnemy.GetComponent<HPDamageEnemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage();
                    Debug.Log($"Атаковал врага на расстоянии {closestDistance}");
                }
            }
        }
        attackbool = false;
    }
    public void TakeDamage()
    {
        if (currentHealth <= 0) return;
        currentHealth -= HpdamEn.damageEnemy;   
        Debug.Log($"Игрок получил урон.");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;
    }
}