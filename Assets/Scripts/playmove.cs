using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmove : MonoBehaviour
{

    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    public float jumpCool;
    public float airMult;
    bool jReady;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public float groundDrag;

    public float speedMo;

    public Transform orient;

    float horiInp;
    float vertInp;

    Vector3 moveDir;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    void Update()
    {
        InputMo();
        SpeedControl();

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 10f + 0.2f, whatIsGround);

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

    }

    private void FixedUpdate()
    {
        MovePlay();
    }

    private void InputMo()
    {
        horiInp = Input.GetAxisRaw("Horizontal");
        vertInp = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && jReady && grounded)
        {
            jReady = false;

            Jump();

            Debug.Log("jumping");

            Invoke(nameof(ResJump), jumpCool);
        }
    }

    private void MovePlay()
    {
        moveDir = orient.forward * vertInp + orient.right * horiInp;

        if(grounded)
            rb.AddForce(moveDir.normalized * speedMo * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDir.normalized * speedMo * 10f * airMult, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > speedMo)
        {
            Vector3 limitedVel = flatVel.normalized * speedMo;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResJump()
    {
        jReady = true;
    }
}
