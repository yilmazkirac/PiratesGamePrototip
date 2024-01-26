public interface IState
{
    void EnterState(EnemyController enemy);
    void UpdateState(EnemyController enemy);
    void ExitState(EnemyController enemy);
}
