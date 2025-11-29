using UnityEngine;

public class DamageAn : MonoBehaviour
{
    public int damageAn;
    void OnCollisionEnter(Collision collision)
    {
        Helth healthAn = collision.gameObject.GetComponent<Helth>();
        if (healthAn != null)
        {
            healthAn.TakeDamage(damageAn);
            Debug.Log("Нанесено " + damageAn + " урона " + collision.gameObject.name);
        }
    }
}
