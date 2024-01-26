using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float Timer = 0;
    public float Distance;
    public Transform Player;
    public Animator EnemyAnimator;
    public Transform[] WayPoint;
    public NavMeshAgent EnemyAgent;

    private IState currentState;
    private void Start()
    {
        currentState=new IdleState();
        currentState.EnterState(this);
    }

    private void Update()
    {
        Distance=Vector3.Distance(Player.position,transform.position);
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        currentState.ExitState(this);
        currentState=newState;
        currentState.EnterState(this);
    }
}
