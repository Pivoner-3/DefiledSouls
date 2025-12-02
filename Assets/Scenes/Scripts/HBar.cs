using UnityEngine;
using UnityEngine.UI;

public class HBar : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float damage = 10f;
    [SerializeField] public Image hImage;

    void Start()
    {
        hImage = GetComponent<Image>();
        currentHealth = maxHealth;
    }
    void Update()
    {
        hImage.fillAmount = currentHealth / maxHealth;
    }
}