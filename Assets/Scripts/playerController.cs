using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private gameController gc;
    private BackgroundBehavior backgroundBehavior;
    private Vector2 _moveDir = Vector2.zero;


    private bool allowJump = true;

    public CoinManager coinManager;

    public AudioClip jumpSound;

    public AudioSource audioSource;

    private bool jumpInput;
    public string currentSide;


    private void Start()
    {
        gc = FindObjectOfType<gameController>();
        backgroundBehavior = FindObjectOfType<BackgroundBehavior>();
    }

    private void Update()
    {
        // Handle input in Update
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // left/right arrow or A/D
        _moveDir.x = horizontalInput;

        _isSprinting = Input.GetKey(KeyCode.LeftShift); // Sprint check
        finalMoveSpeed = _isSprinting ? _moveSpeed * sprintMultiplier : _moveSpeed;

        if(Input.GetButtonDown("Jump") && allowJump) jumpInput = true;

        float rotation = transform.rotation.z;
        if(rotation < .60 && rotation > -.60) currentSide = "Blue";
        if(rotation >= .60) currentSide = "Yellow";
        if(rotation <= -.60) currentSide = "Red";
    }


    private void FixedUpdate()
    {
        MovementUpdate();
    }


    private void MovementUpdate()
    {

        _rb.velocity = new Vector2(_moveDir.normalized.x * finalMoveSpeed, _rb.velocity.y);

        //Rotation
        float HorizontalInput = Input.GetAxisRaw("Horizontal"); // left/right arrow or A/D

        if (!allowJump)
        {
            _rb.angularVelocity = 0f; // Reset angular velocity to ensure consistent rotation speed
            transform.Rotate(Vector3.forward, -HorizontalInput * rotationSpeed * Time.deltaTime);
        }

        if (jumpInput) Jump();
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        audioSource.PlayOneShot(jumpSound);
        allowJump = false;
        jumpInput = false;
    }

    public void setAllowJump(bool jump)
    {
        allowJump = jump;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathZone" || collision.gameObject.tag == "Obstacle")
        {
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
        //coin adding deleted 
    }

    public string getCurrentSide(){
        return currentSide;
    }
}