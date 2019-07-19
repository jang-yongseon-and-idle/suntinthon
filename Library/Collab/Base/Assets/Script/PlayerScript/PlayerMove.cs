using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isJump = false; 
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    public bool facingRight;
    public bool key = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    { 
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            isJump = true;
        }
    }
  
        private void FixedUpdate()
    {

        Move();
        Jump();

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            anim.SetBool("isGround", true);
        }
        else
        {
            anim.SetBool("isGround", false);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }
    private void Jump()
    {
        if (!isJump)
        {
            anim.SetBool("isJump", false);
            return;
        }
        rb.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
        rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
        anim.SetBool("isJump", true);
        isJump = false;
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        anim.SetBool("isMove", false);
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            anim.SetBool("isMove", true);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            anim.SetBool("isMove", true);
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && facingRight) Flip();
        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight) Flip();
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Trap")
        {
            Debug.Log("Dead");
            SceneManager.LoadScene("GameOver");
        }

    }
}
