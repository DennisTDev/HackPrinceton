using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED_MULTIPLIER = 100f;
    private const float JUMP_MULTIPLIER = 1000f;
    public float speed;
    public float runSpeed;
    public float jumpForce;
    public bool locked;

    private Rigidbody rb;
    private Camera view;
    private bool isGrounded;
    private float selectedSpeed;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        view = this.GetComponentInChildren<Camera>();
        isGrounded = true;
        selectedSpeed = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!locked)
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Jump();
            }
            selectedSpeed = Input.GetButton("Fire1") ? runSpeed : speed;
            rb.AddForce(view.transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * (selectedSpeed * SPEED_MULTIPLIER), 0, Input.GetAxis("Vertical") * (selectedSpeed * SPEED_MULTIPLIER))));
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Jump()
    {
        rb.AddForce(transform.up * (jumpForce * JUMP_MULTIPLIER));
        isGrounded = false;
    }
}
