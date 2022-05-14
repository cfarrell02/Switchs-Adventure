using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(5, 5);
    [SerializeField] AudioClip jumpSFX,deathSFX;
    Rigidbody2D rigidBody;
    Animator animator;
    CapsuleCollider2D bodyCollider;
    BoxCollider2D feetCollider;

    bool isAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) return;
        Run();
        FlipSprite();
        Jump();
        Die();

    }
    private void Run()
    {
        float movement = Input.GetAxis("Horizontal");

        Vector2 playerVelocity = new Vector2(movement * runSpeed, rigidBody.velocity.y);  //x value is horizontal, y is vertical (from Rigidbody)
        rigidBody.velocity = playerVelocity;

        if (Mathf.Abs(rigidBody.velocity.x) > 0) // if player is moving
        {  
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

    }
    private void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")))
        {
            //animator.SetTrigger("Dying")

           // AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position,.5f);
            AudioSource audio =  GetComponent<AudioSource>();
            audio.clip = deathSFX;
            audio.Play();
            transform.Rotate(0, 0, 90);
            animator.enabled = false;
            rigidBody.velocity = deathKick;
            isAlive = false;
            StartCoroutine(ProcessDeath());
        }
    }
    IEnumerator ProcessDeath()
    {
        yield return new WaitForSecondsRealtime(2f);
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
        private void FlipSprite()
    {
        if (Mathf.Abs(rigidBody.velocity.x) > 0)
        {
            float direction = Mathf.Sign(rigidBody.velocity.x);
            transform.localScale = new Vector2(direction, 1f);
        }

    }

    private void Jump()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            AudioSource.PlayClipAtPoint(jumpSFX, transform.position);
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rigidBody.velocity += jumpVelocity;
        }
    }
}
