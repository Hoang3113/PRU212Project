using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    private bool isJumping = false;
    private bool isDelayingJump = false;
    private bool hasPressedJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpable = Physics2D.OverlapCircle(target.position, 0.3f, floor);
        huong = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(huong * speed, rb.velocity.y);
        // if (vertical >0.1 && jumpable)
        // {
        //    Jump();
        // }

        if (jumpable && !Input.GetKey(KeyCode.UpArrow))
        {
            isJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isJump || jumpable)
            {
                Jump();
                isJumping = false;
            }
        }


        //anim.SetBool("attack", false);

        Attack();
        //flip
        flip();
        //anim
        anim.SetFloat("move", Mathf.Abs(huong));
    }

    private void flip()
    {
        if (isFacingRight && huong < 0 || !isFacingRight && huong > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    private void Jump()
    {
        if (!isJumping && !isDelayingJump) // Chỉ cho phép nhảy nếu nhân vật không đang trong quá trình nhảy và coroutine không chạy
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isJumping = true; // Đặt cờ là nhân vật đã nhảy
            hasPressedJump = false;

            StartCoroutine(DelayJump()); // Bắt đầu coroutine để đợi 1 giây trước khi cho phép nhảy tiếp
        }
    }

    private IEnumerator DelayJump()
    {
        isDelayingJump = true; // Đặt cờ là coroutine đang chạy

        yield return new WaitForSeconds(0.3f); // Đợi 1 giây

        while (!Input.GetKey(KeyCode.UpArrow) && !hasPressedJump) // Đợi cho đến khi người chơi nhấn nút nhảy tiếp hoặc đã nhấn nút nhảy trong lần nhảy trước
        {
            yield return null;
        }

        isJumping = false; // Đặt lại cờ là nhân vật không còn trong quá trình nhảy
        isDelayingJump = false; // Đặt lại cờ là coroutine không còn chạy

        hasPressedJump = true; // Đặt cờ là người chơi đã nhấn nút nhảy trong lần nhảy hiện tại
    }

    private void Attack()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }

    
}
