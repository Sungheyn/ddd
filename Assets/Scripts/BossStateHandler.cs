using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateHandler : MonoBehaviour
{
    [SerializeField] private float HP, MaxHp, Damage, Speed, CritRatio, CritPercent, Radius;
    [SerializeField] private Collider2D[] Collider;
    [SerializeField] private LayerMask layer;
    void Update()
    {
        Collider = Physics2D.OverlapCircleAll(transform.position, Radius, layer);
        foreach (Collider2D c in Collider)
        {
            if (c.CompareTag("Player"))
            {
                Debug.Log("Player Detected");
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
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
