using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 lookatpos = Input.mousePosition;
        lookatpos.z = transform.position.z - Camera.main.transform.position.z;
        lookatpos = Camera.main.ScreenToWorldPoint(lookatpos);
        transform.up = lookatpos - transform.position;
    }
    
}
