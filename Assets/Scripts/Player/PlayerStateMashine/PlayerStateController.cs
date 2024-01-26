using UnityEngine;
public class PlayerStateController : MonoBehaviour
{
    IPlayerState currentState;
    public PlayerMovement PlayerMovement;
    public AnimationController AnimationController;


    private void Start()
    {
        currentState=new DefoultState();
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IPlayerState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
