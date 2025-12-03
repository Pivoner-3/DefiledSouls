using UnityEngine;
using UnityEngine.UI;

public class HBar : MonoBehaviour
{
    public HPDamagePlayer InfoPlayer;
    [SerializeField] public Image hImage;

    void Start()
    {
        hImage = GetComponent<Image>();
        if (hImage == null)
        {
            GameObject healthBar = GameObject.Find("HP player");
            if (healthBar != null)
            {
                hImage = healthBar.GetComponent<Image>();
            }
        }

        if (InfoPlayer == null)
        {
            GameObject healtDamPl = GameObject.Find("HPDamagePlayer");
            if (healtDamPl != null)
            {
                InfoPlayer = healtDamPl.GetComponent<HPDamagePlayer>();
            }
        }

        InfoPlayer.currentHealth = InfoPlayer.maxHealth;
    }
    void Update()
    {
        hImage.fillAmount = InfoPlayer.currentHealth / InfoPlayer.maxHealth;
    }
}