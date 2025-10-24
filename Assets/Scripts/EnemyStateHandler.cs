using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateHandler : MonoBehaviour
{
    [SerializeField] private float HP, MaxHp, Damage, Speed, CritRatio, CritPercent;
    public void TakeDamage(float Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            HP = 0;
            Death();
        }
    }
    private void Death()
    {
        gameObject.SetActive(false);
    }
}
