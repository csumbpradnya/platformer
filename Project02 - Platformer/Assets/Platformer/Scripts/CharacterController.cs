using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpForce = 10f;
    public float maxRunSpeed = 6f;
    public float jumpBonus = 6f;
    public bool feetInContactWithGround;
    private Rigidbody body;

    private Collider collider;

    private Animator animComp;
    // Start is called before the first frame update
    void Start()
    {
        animComp = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        body = GetComponent<Rigidbody>();
        Bounds collider = GetComponent<Collider>().bounds;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down, collider.extents.y + 0.1f);
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        if (feetInContactWithGround && Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        else if (body.velocity.y > 0f && Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpBonus, ForceMode.Force);
        }

        if (Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 5f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
        if (feetInContactWithGround && Input.GetKey(KeyCode.LeftShift))
        {
            maxRunSpeed = 20f;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            maxRunSpeed = 6f;
        }
        
        animComp.SetFloat("speed", body.velocity.magnitude);
        animComp.SetBool("isJump", !feetInContactWithGround);
        animComp.SetBool("isTurbo", Input.GetKey(KeyCode.LeftShift));
    }
}
