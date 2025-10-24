using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackPoint : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            var enemy = collision.GetComponent<EnemyStateHandler>();
            if (enemy != null)
            {
                enemy.TakeDamage(PlayerStateHandler.instance.Damage);
            }
        }
    }
}
