using UnityEngine;

public class PlayerStats : MonoBehaviour, IInteract
{
    public int Health ;
    private int currentHealth;

    private void Start()
    {
       currentHealth=Health;
    }
    public void Execute()
    {
        TakeDamamge(25);
    }

    private void TakeDamamge(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;           
        }
        SetText();
    }
    public void SetHealt(int Heal)
    {
        currentHealth += Heal;
        if (currentHealth >Health)
        {
            currentHealth = Health;           
        }
        SetText();
    }

    private void SetText()
    {
        UIManager.Instance.HealtText.text=currentHealth.ToString();
    }
}
