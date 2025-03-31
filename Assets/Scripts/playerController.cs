using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public Rigidbody2D _rb;
    public float _moveSpeed;

    private bool _isSprinting;
    private float finalMoveSpeed;
    private float sprintMultiplier = 2f;
    public float _jumpForce = 10f;


    private Vector2 _moveDir = Vector2.zero;


    private bool _isGrounded = false;

    private Transform groundCheck;

    private void Update()
    {
        //Rotation
        float rotateInput = Input.GetAxisRaw("Horizontal"); // left/right arrow or A/D
        transform.Rotate(Vector3.forward, -rotateInput * rotationSpeed * Time.deltaTime);

        //Side to Side movement
        _moveDir.x = Input.GetAxisRaw("Horizontal");

        //Sprint check
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        finalMoveSpeed = _isSprinting ? _moveSpeed * sprintMultiplier : _moveSpeed;


        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        if (jumpInput && _isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            Debug.Log("I'm jumping");
        }
    }


    private void FixedUpdate()
    {
        MovementUpdate();
    }


    private void MovementUpdate()
    {

        _rb.velocity = new Vector2(_moveDir.normalized.x * finalMoveSpeed, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" ||
            collision.gameObject.tag == "Red" ||
            collision.gameObject.tag == "Yellow" ||
            collision.gameObject.tag == "Blue")
        {
            _isGrounded = true;
            Debug.Log("I'm Grounded!");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" ||
            collision.gameObject.tag == "Red" ||
            collision.gameObject.tag == "Yellow" ||
            collision.gameObject.tag == "Blue")
        {
            _isGrounded = false;
            Debug.Log("I'm Flying!");
        }
    }

}
