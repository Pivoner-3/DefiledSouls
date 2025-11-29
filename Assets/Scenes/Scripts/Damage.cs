using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    void OnCollisionEnter(Collision collision)
    {
        Helth health = collision.gameObject.GetComponent<Helth>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Debug.Log("Нанесено " + damage + " урона " + collision.gameObject.name);
        }
    }
}
