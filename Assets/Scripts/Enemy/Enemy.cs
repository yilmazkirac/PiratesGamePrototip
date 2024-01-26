public class Enemy : EnemyStats, IEnemy
{ 
    private void Start()
    {
        currentHealt = Health;
    }
    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        if (currentHealt <= 0)
        {
            gameObject.GetComponent<ItemObject>().Execute();
            Destroy(gameObject);
        }
    }
}
