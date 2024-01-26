using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemySwordAttackInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {       
        IInteract player = other.GetComponent<IInteract>();
        if (player != null)
        {
            player.Execute();
        }
    }
}
