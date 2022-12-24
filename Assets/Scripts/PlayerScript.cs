using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    Vector3 movement;
    private int direction =1;
    bool isJumping = false;
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        Run();
        Jump();
        Attack();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        animator.SetBool("isJump", false);
    }

    void Run() {
        Vector3 moveVelocity = Vector3.zero;
        animator.SetBool("isRun", false);

        if (Input.GetAxisRaw("Horizontal") < 0) {
            direction = -1;
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(direction, 1, 1);
            if (!animator.GetBool("isJump"))
                 animator.SetBool("isRun", true);
        }
        if (Input.GetAxisRaw("Horizontal") > 0) {
            direction = 1;
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(direction, 1, 1);
            if (!animator.GetBool("isJump"))
                 animator.SetBool("isRun", true);
        }
        transform.position += moveVelocity * moveForce * Time.deltaTime;
    }

    void Jump() {
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && !animator.GetBool("isJump")) {
            isJumping = true;
            animator.SetBool("isJump", true);
        }
        if (!isJumping) {
            return;
        }
        rigidBody.velocity = Vector2.zero;
        Vector2 jumpVelocity = new Vector2(0, jumpForce);
        rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
        isJumping = false;
    }

    void Attack() {
        if (Input.GetKeyDown(KeyCode.J)) {
            animator.SetTrigger("attack");
        }
    }
}
    