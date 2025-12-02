using UnityEngine;

public class HPDamageEnemy : MonoBehaviour
{
    private float attackCoolDown = 1f;

    public HBarEnem HPbarEnemy;
    void Start()
    {
        HPbarEnemy.currentHealthEnemy = HPbarEnemy.maxHealthEnemy;
    }
    void Update()
    {
        
    }
}
