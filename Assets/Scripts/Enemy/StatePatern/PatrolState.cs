using UnityEngine;

public class PatrolState : IState
{   
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAgent.speed = 2f;
        enemy.Timer = 0;
        enemy.EnemyAnimator.SetBool("isPatrolling", true);
    }

    public void ExitState(EnemyController enemy)
    {
        enemy.EnemyAnimator.SetBool("isPatrolling", false);
        enemy.EnemyAgent.SetDestination(enemy.transform.position);
    }

    public void UpdateState(EnemyController enemy)
    {
        if (enemy.EnemyAgent.remainingDistance <= enemy.EnemyAgent.stoppingDistance)
        {
            enemy.EnemyAgent.SetDestination(enemy.WayPoint[Random.Range(0, enemy.WayPoint.Length)].position);
        }   
        enemy.Timer += Time.deltaTime;
        if (enemy.Timer>5f)
        {
            enemy.ChangeState(new IdleState());
        }
        else if (enemy.Distance<5f)
        {
            enemy.ChangeState(new ChaseState());
        }
    }
}
