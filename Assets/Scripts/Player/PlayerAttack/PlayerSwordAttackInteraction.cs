using UnityEngine;

public class PlayerSwordAttackInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {       
        IEnemy enemy = other.GetComponent<IEnemy>();
        if (enemy != null)
        {           
            enemy.TakeDamage(25);
        }
    }
}
