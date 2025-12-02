using UnityEngine;
using UnityEngine.UI;
public class HPDamagePlayer : MonoBehaviour
{
    public HBar HPbar;
    public float damagePlayer = 10f;
    public KeyCode attack = KeyCode.R;
    void Start()
    {
        HPbar.currentHealth = HPbar.maxHealth;
    }
    void Update()
    {
        if (Input.GetKeyDown(attack))
        {

        }
    }
}
