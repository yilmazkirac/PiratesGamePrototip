using UnityEngine;

public class DefoultState : IPlayerState
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
        if (Input.GetMouseButtonDown(0)&& GunManager.Instance.IsSword)
        {
            player.ChangeState(new PlayerAttackState());
        }
    }
}
