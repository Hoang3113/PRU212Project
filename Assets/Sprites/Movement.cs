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
    public Sprite openChestSprite; // Hình ảnh đại diện cho hòm đã mở
    [SerializeField] public Text keyText; // Text để hiển thị số lượng chìa khóa
    private SpriteRenderer spriteRenderer; // Đối tượng SpriteRenderer của hòm
    private int keysCount = 0; // Số lượng chìa khóa hiện có
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateKeyText();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chest") && !isOpen)
        {
            OpenTheChest();
        }
    }

    private void OpenTheChest()
    {
        // Thay đổi hình ảnh của hòm thành "open chest"
        spriteRenderer.sprite = openChestSprite;
        isOpen = true;

        // Cộng 1 vào số lượng chìa khóa
        keysCount++;
        UpdateKeyText();

        // Thêm các hành động khác khi hòm được mở
    }

    private void UpdateKeyText()
    {
        // Cập nhật số lượng chìa khóa trên màn hình
        if (keyText != null)
        {
            keyText.text = "Keys: " + keysCount;
        }

    }
    // Update is called once per frame
    void Update()
    {
        jumpable = Physics2D.OverlapCircle(target.position, 0.3f, floor);
        huong = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(huong * speed, rb.velocity.y);
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
        rb.velocity = new Vector2(rb.velocity.x, jump);
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