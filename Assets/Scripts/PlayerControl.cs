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
    private float DashForce = 0f;
    [SerializeField]
    private float JumpForce = 10f;
    [SerializeField]
    private Rigidbody2D rigid;
    private bool CanJump = false;
    private float DashVal = 0f, delta = 0f;
    void Awake()
    {
        rigid = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal") + DashVal, rigid.velocity.y);
        if (CanJump)
        {
            rigid.AddForce(Vector2.up * JumpForce * 10, ForceMode2D.Force);
            CanJump = !CanJump;
        }
    }
    private void Update()
    {
        delta += Time.deltaTime;
        Jump();
        Dash();
    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && delta >= 0.5f)
        {
            StartCoroutine(DashEvaling());
            delta = 0;
        }
    }
    IEnumerator DashEvaling()
    {
        float dir = rigid.velocity.x >= 0 ? 1 : -1;
        DashVal = DashForce * dir; 
        yield return new WaitForSeconds(0.15f);
        DashVal = 0;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float length = 0.55f;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, length, layerMask);
            CanJump = hit;
        }
    }
}
