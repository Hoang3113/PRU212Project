using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    public Transform target;
    public LayerMask floor;

    private bool isFacingRight = false;
    private float huong;
    private float vertical;
    private Rigidbody2D rb;
    private Animator anim;
    private bool jumpable;
    private bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpable = Physics2D.OverlapCircle(target.position, 0.1f, floor);
        huong = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(huong*speed, rb.velocity.y);
        //if (vertical >0.1 && jumpable)
        //{
        //    Jump();
        //}

        if (jumpable && !Input.GetKey(KeyCode.W))
        {
            isJump = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isJump || jumpable)
            {
                Jump();
                isJump = !isJump;
            }
        }
        //anim.SetBool("attack", false);
        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }

        //flip
        flip();
        //anim
        anim.SetFloat("move", Mathf.Abs(huong));
    }

    private void flip()
    {
        if (isFacingRight && huong<0 || !isFacingRight && huong > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2 (rb.velocity.x, jump);
    }

    private void Attack()
    {
        
    }
}
