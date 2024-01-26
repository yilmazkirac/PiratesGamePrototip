using UnityEngine;

public class PlayerAttackState : IPlayerState
{
    public void EnterState(PlayerStateController player)
    {
       
    }

    public void ExitState(PlayerStateController player)
    {

    }

    public void UpdateState(PlayerStateController player)
    {
        player.PlayerMovement.Rotation();
        player.PlayerMovement.Move();
        if (Input.GetMouseButton(0))
        {
            player.AnimationController.SetBool("Attack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            player.AnimationController.SetBool("Attack", false);
            player.ChangeState(new DefoultState());
        }
    }
}
