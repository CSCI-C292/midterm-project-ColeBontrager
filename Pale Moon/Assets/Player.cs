using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] float _fallSpeed;
    [SerializeField] float _jumpForce;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
            rb.AddForce(new Vector2(0, _jumpForce));
        }
        
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed * Time.deltaTime, rb.velocity.y);
        
        
    }
}
