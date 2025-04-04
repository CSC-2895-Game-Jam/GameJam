using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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


    private bool allowJump = true;

    private void Update()
    {
        //Rotation
        float HorizontalInput = Input.GetAxisRaw("Horizontal"); // left/right arrow or A/D

        if (!allowJump)
        {
            _rb.angularVelocity = 0f; // Reset angular velocity to ensure consistent rotation speed
            transform.Rotate(Vector3.forward, -HorizontalInput * rotationSpeed * Time.deltaTime);
        }

        //Side to Side movement
        _moveDir.x = HorizontalInput;

        //Sprint check
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
        finalMoveSpeed = _isSprinting ? _moveSpeed * sprintMultiplier : _moveSpeed;


        bool jumpInput = Input.GetKeyDown(KeyCode.Space);

        if (jumpInput && allowJump)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
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

    public void setAllowJump(bool jump){
        allowJump = jump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController gc = FindObjectOfType<gameController>();
        
        if(collision.gameObject.tag == "DeathZone"){
            // Teleport player back to last checkpoint
            if (gc != null)
            {
                gc.telportToLastCheckpoint();
                Debug.Log("teleporting...!");
            }
            else
            {
                Debug.Log("gc not found!");
            }
            
        }

        if(collision.gameObject.tag == "Obstacle"){
            // Teleport player back to last checkpoint
            if (gc != null)
            {
                gc.telportToLastCheckpoint();
                Debug.Log("teleporting...!");
            }
            else
            {
                Debug.Log("gc not found!");
            }
            
        }


        
    }
}
