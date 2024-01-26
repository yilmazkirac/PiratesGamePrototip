using UnityEngine;

public class IdleState : IState
{   
    public void EnterState(EnemyController enemy)
    {
        enemy.Timer = 0;
    }

    public void ExitState(EnemyController enemy)
    {

    }

    public void UpdateState(EnemyController enemy)
    {
        enemy.Timer += Time.deltaTime;
        if (enemy.Timer>5f)
        {
            enemy.ChangeState(new PatrolState());
        }
        else if (enemy.Distance<5f)
        {           
            enemy.ChangeState(new ChaseState());
        }
    }
}
