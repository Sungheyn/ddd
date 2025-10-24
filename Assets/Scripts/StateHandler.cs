using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    [SerializeField] public float HP, MaxHp, Damage, Speed, CritRatio, CritPercent;
    public static StateHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
    }
    public bool TakeDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Death();
            return true; // Player is dead
        }
        return false; // Player is still alive
    }
    private void Death()
    {
        gameObject.SetActive(false);

        // Implement death logic here
    }
}
