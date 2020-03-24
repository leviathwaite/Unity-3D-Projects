using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // TODO do I need starting health?
    [SerializeField]
    private int currentHealth = 100;
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private bool oneHitKill = false;
    [SerializeField]
    private bool isDead = false;

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    public bool IsDead
    {
        get { return isDead; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CheckHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckHealth()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth == 0)
        {
            isDead = true;
        }
    }

    private void ReduceHealth(int value)
    {
        currentHealth -= value;
        CheckHealth();
    }

    private void IncreaseHealth(int value)
    {
        currentHealth += value;
        CheckHealth();
    }

    public void ReduceMaxHealth(int value)
    {
        if(oneHitKill)
        {
            currentHealth = 0;
        }
        else
        {
            maxHealth -= value;
        }

        CheckHealth();
    }

    public void IncreaseMaxHealth(int value)
    {
        maxHealth += value;
        CheckHealth();
    }
}
