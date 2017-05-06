using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public float baseHealth;
    private float currentHealth;

    //Events
    public delegate void StatusEvent();

    private StatusEvent OnHealthZero;
    private StatusEvent OnHealthDown;

    private void Awake()
    {
        currentHealth = baseHealth;
    }

    //Event Subsciption
    public void SubscribeOnHealthZero(StatusEvent e)
    {
        OnHealthZero += e;
    }
    public void UnsubscribeOnHealthZero(StatusEvent e)
    {
        OnHealthZero -= e;
    }
    public void SubscribeOnHealthDown(StatusEvent e)
    {
        OnHealthDown += e;
    }
    public void UnsubscribeOnHealthDown(StatusEvent e)
    {
        OnHealthDown -= e;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            OnHealthZero();
        }
    }
    //Reciever functions
    public void Damage(float damage)
    {
        currentHealth -= damage;
        OnHealthDown();
    }

}