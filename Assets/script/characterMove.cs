using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump = new Vector3(0, 1, 0);
    public Vector3 move = new Vector3(0, 0, 1);
    public Vector3 fanLeft = new Vector3(-1, 0, 0);
    public const float jumpForce = 1f;
    public const float fanForce = 20f;
    // public const float fanForceLeft = 100f;
    public const float movementSpeed = 5;
    private platformControl platformControl;

    private string characterMode = "Stop";
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        platformControl = GameObject.FindObjectOfType<platformControl>();

        _animator.enabled = false;
    }
    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Spring")
        {
            characterMode = "Running";
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            animation animation = coll.gameObject.GetComponent<animation>();
            animation.startAni();
        }
        if (coll.gameObject.tag == "Running")
        {
            characterMode = "Running";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fan")
        {
            if (characterMode == "Running")
            {
                characterMode = "OnWind";
                transform.position += move * Time.deltaTime * movementSpeed * 5;
            }
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // running = true;
        if (other.gameObject.tag == "Fan")
        {
            float distance = Mathf.Abs(other.gameObject.transform.position.y - transform.position.y);
            characterMode = "OnWind";
            rb.AddForce(jump * fanForce / distance, ForceMode.Force);
        }
        if (other.gameObject.tag == "FanLeft")
        {
            // float distance = Mathf.Abs(other.gameObject.transform.position.z - transform.position.z);
            // Debug.Log(fanLeft * fanForceLeft / distance);
            // rb.AddForce(fanLeft * fanForceLeft / distance, ForceMode.VelocityChange);
            rb.velocity = new Vector3(0, 0, -10);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FanLeft")
        {
            characterMode = "Running";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("E!!!");
            characterMode = "Running";
            _animator.enabled = true;
        }
        if (characterMode == "Running")
        {
            transform.position += move * Time.deltaTime * movementSpeed;
        }
    }
}
