using UnityEngine;

public class AttackState : IState
{   
    public void EnterState(EnemyController enemy)
    {
        enemy.EnemyAnimator.SetBool("isAttacking", true);
        Debug.Log("Enter Attack State");
    }

    public void ExitState(EnemyController enemy)
    {
        enemy.EnemyAnimator.SetBool("isAttacking", false);
        Debug.Log("Exit Attack State");
    }

    public void UpdateState(EnemyController enemy)
    {
        enemy.transform.LookAt(enemy.Player);
        if (enemy.Distance >= 3f)
        {
            enemy.ChangeState(new ChaseState());
        }
    }
}
