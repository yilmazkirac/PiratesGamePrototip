using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteract interact=other.GetComponentInParent<IInteract>();
            if (interact!=null)
            {
             
                interact.Execute();
               
            }
        }
    }
}
