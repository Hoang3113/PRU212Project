using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public float active_range;
    public Transform player;
    public Animator animator;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, rb.position) <= active_range)
        {
            animator.SetTrigger("Active");
        }
    }
}
