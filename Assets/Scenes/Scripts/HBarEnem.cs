using UnityEngine;
using UnityEngine.UI;
public class HBarEnem : MonoBehaviour
{
    [SerializeField] public Image hImageEnemy;
    public HPDamagePlayer HPDamagePl;
    public HPDamageEnemy HPDamageEn;
    void Start()
    {
        hImageEnemy = GetComponent<Image>();
        if (hImageEnemy == null)
        {
            GameObject healthBar = GameObject.Find("HP angel");
            if (healthBar != null)
            {
                hImageEnemy = healthBar.GetComponent<Image>();
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

        if (HPDamageEn == null)
        {
            GameObject healtDamPl = GameObject.Find("HPDamagePlayer");
            if (healtDamPl != null)
            {
                HPDamagePl = healtDamPl.GetComponent<HPDamagePlayer>();
            }
        }
        HPDamageEn.currentHealthEnemy = HPDamageEn.maxHealthEnemy;
    }
    void Update()
    {
        hImageEnemy.fillAmount = HPDamageEn.currentHealthEnemy / HPDamageEn.maxHealthEnemy;
    }
}
