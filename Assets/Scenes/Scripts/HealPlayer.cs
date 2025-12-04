using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public float healOfPlayer = 30f;
    private float nextHeallTime = 1f;
    public float heallDelay = 1f;
    private float lastHealTime = 0f;
    private bool canHeal = false;

    public HBar hpPlayer;
    public HPDamagePlayer InfoPlayer;
    void Start()
    {
        if (InfoPlayer == null)
        {
            GameObject healtDamPl = GameObject.Find("HPDamagePlayer");
            if (healtDamPl != null)
            {
                InfoPlayer = healtDamPl.GetComponent<HPDamagePlayer>();
            }
        }
    }
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 2f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player") && Time.time >= nextHeallTime)
            {
                AttackPlayer(hit.gameObject);
                nextHeallTime = Time.time + heallDelay;
            }
        }
    }
    public void TakeDamage()
    {
        while(InfoPlayer.currentHealth < InfoPlayer.maxHealth)
            InfoPlayer.currentHealth += healOfPlayer;
            Debug.Log($"Здоровье игрока регенирируется.");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canHeal)
        {
            AttackPlayer(collision.gameObject);
            StartCooldown();
        }
    }
    private void AttackPlayer(GameObject player)
    {
        HPDamagePlayer playerHealth = player.GetComponent<HPDamagePlayer>();

        if (playerHealth != null)
        {
            playerHealth.currentHealth += healOfPlayer;
            Debug.Log($"Игрок получил {healOfPlayer} дополнительного здоровья. Осталось HP: {playerHealth.currentHealth}");
        }
    }
    private void StartCooldown()
    {
        canHeal = false;
        lastHealTime = Time.time;
    }
}