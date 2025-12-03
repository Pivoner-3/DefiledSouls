using UnityEngine;

public class HPDamageEnemy : MonoBehaviour
{
    public float damageEnemy = 15f;
    public float attackDelay = 1f;
    private float nextAttackTime = 0f;
    private float lastAttackTime = 0f;
    private bool canAttack = false;

    public float maxHealthEnemy = 120f;
    public float currentHealthEnemy;
    public HBarEnem HPbarEnemy;
    public HPDamagePlayer HPDamagePl;
    void Start()
    {
        if (HPbarEnemy == null)
        {
            GameObject healtDamEn = GameObject.Find("HBarEnem");
            if (healtDamEn != null)
            {
                HPbarEnemy = healtDamEn.GetComponent<HBarEnem>();
            }
        }
        if (HPDamagePl == null)
        {
            GameObject healtDamPl = GameObject.Find("HPDamagePlayer");
            if (healtDamPl != null)
            {
                HPDamagePl = healtDamPl.GetComponent<HPDamagePlayer>();
            }
        }
        currentHealthEnemy = maxHealthEnemy;
    }
    void Update()
    {
        // Проверяем рядом игрока
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player") && Time.time >= nextAttackTime)
            {
                AttackPlayer(hit.gameObject);
                nextAttackTime = Time.time + attackDelay;
            }
        }
    }
    public void TakeDamage()
    {
        currentHealthEnemy -= HPDamagePl.damagePlayer;
        Debug.Log($"Монстр получил урон.");
        if (currentHealthEnemy <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            AttackPlayer(collision.gameObject);
            StartCooldown();
        }
    }
    private void AttackPlayer(GameObject player)
    {
        // Получаем HBar у игрока, а не HPDamagePlayer
        HPDamagePlayer playerHealth = player.GetComponent<HPDamagePlayer>();

        if (playerHealth != null)
        {
            playerHealth.currentHealth -= damageEnemy;
            Debug.Log($"Игрок получил {damageEnemy} урона от монстра. Осталось HP: {playerHealth.currentHealth}");
        }
    }
    private void StartCooldown()
    {
        canAttack = false;
        lastAttackTime = Time.time;
    }
    private void Die()
    {
        Debug.Log("Монстр погиб!");
        Destroy(gameObject);
    }
}
