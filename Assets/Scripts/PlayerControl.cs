using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private float JumpForce = 10f;
    [SerializeField]
    private Rigidbody2D rigid;
    private bool CanJump = false;
    void Awake()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rigid.velocity.y);
        if (CanJump)
        {
            rigid.AddForce(Vector2.up * JumpForce * 10, ForceMode2D.Force);
            CanJump = !CanJump;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float length = 0.55f;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, length, layerMask);
            CanJump = hit;
        }
    }
}
