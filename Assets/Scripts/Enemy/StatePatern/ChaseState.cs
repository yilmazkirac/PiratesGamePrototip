using UnityEngine;

public class ChaseState : IState
{   
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAgent.speed = 3f;
        enemy.EnemyAnimator.SetBool("isChasing", true);
        Debug.Log("Enter Chese State");
    }

    public void ExitState(EnemyController enemy)
    {
        enemy.EnemyAnimator.SetBool("isChasing", false);
        enemy.EnemyAgent.SetDestination(enemy.transform.position);
        Debug.Log("Exit Chese State");
    }

    public void UpdateState(EnemyController enemy)
    {
        enemy.EnemyAgent.SetDestination(enemy.Player.position);
        if (enemy.Distance <3f)
        {
            enemy.ChangeState(new AttackState());
        }
        else if (enemy.Distance>10f)
        {           
            enemy.ChangeState(new PatrolState());
        }
    }
}
