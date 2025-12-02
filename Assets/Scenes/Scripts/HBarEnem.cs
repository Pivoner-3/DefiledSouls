using UnityEngine;
using UnityEngine.UI;
public class HBarEnem : MonoBehaviour
{
    public float maxHealthEnemy = 120f;
    public float currentHealthEnemy;
    public float damageEnemy = 15f;
    [SerializeField] public Image hImageEnemy;

    void Start()
    {
        hImageEnemy = GetComponent<Image>();
        currentHealthEnemy = maxHealthEnemy;
    }
    void Update()
    {
        hImageEnemy.fillAmount = currentHealthEnemy / maxHealthEnemy;
    }
}
