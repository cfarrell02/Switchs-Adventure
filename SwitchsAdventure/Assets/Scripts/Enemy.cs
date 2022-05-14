using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 0)
        {
            rigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    void OnTriggerExit2D()
    {
        transform.localScale = new Vector2(rigidBody.velocity.x, 1f);
    }

}
