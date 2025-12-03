using UnityEngine;

public class HPDamageEnemy : MonoBehaviour
{
    public float damageEnemy = 15f;
    public float attackCoolDown = 1f;
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
       if (!canAttack)
        {
            if (Time.time - lastAttackTime >= attackCoolDown)
            {
                canAttack = true;
            }
        } 
    }
    public void TakeDamage()
    {
        currentHealthEnemy -= HPDamagePl.damagePlayer;
        Debug.Log($"Монстр получил урон.");
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
        HPDamagePlayer healtDamPl = player.GetComponent<HPDamagePlayer>();
        if (healtDamPl != null)
        {
            healtDamPl.currentHealth -= damageEnemy;
            Debug.Log($"Игрок получил урон от монстра.");
        }
    }
    private void StartCooldown()
    {
        canAttack = false;
        lastAttackTime = Time.time;
    }
}
