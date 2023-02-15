using UnityEngine;

public class Weapon : MonoBehaviour
{
    //variable to set how much damage can be made
    public int damage;
    
    //when sword (box collider) hits the enemy (another collider), enemy gets damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }    
    }
}
