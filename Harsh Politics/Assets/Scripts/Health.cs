
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;

    public int health;
    void Start()
    {
        health = maxHealth;
    }

    //Updates health 
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
