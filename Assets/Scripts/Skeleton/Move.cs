using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Transform player;
    public Transform monter;
    public Transform left;
    public Transform right;
    public Transform init;
    public Animator animator;
    public Rigidbody2D rb;
    public bool flip;
    public float active_range;

    private float l;
    private float r;
    private bool inRange;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        Active();
        if (active)
        {
            Flip();

            inRange = CheckInRangge();
            if (inRange)
            {
                Vector2 target = new Vector2(player.position.x, rb.position.y);
                Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
                animator.SetBool("Move", true);
            }
            else
            {
                //Vector2 target = new Vector2(init.position.x, rb.position.y);
                //Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
                //rb.MovePosition(newPos);
                animator.SetBool("Move", false);
            }
        }
    }

    private bool CheckInRangge()
    {
        l = left.transform.position.x;
        r = right.transform.position.x;
        if (player.transform.position.x >= l && player.transform.position.x <= r)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Flip()
    {
        Vector3 flipped = monter.localScale;
        flipped.z *= -1f;

        if (monter.position.x > player.position.x && flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = false;
        }
        else if (monter.position.x < player.position.x && !flip)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            flip = true;
        }
    }

    public void Active()
    {
        if (Vector2.Distance(player.position, rb.position) <= active_range)
        {
            animator.SetTrigger("Active");
            active = true;
        }
    }
}
