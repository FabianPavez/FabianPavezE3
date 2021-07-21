using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovSpeed;    
    public Rigidbody2D rb;
    private Vector2 direccion;
    
   

    void Update()
    {
        Process();
        
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }
    void Process ()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        direccion = new Vector2(moveX, moveY).normalized;
    }
    void Move()
    {
        rb.velocity = new Vector2(direccion.x * MovSpeed, direccion.y * MovSpeed);
    }
    

}
