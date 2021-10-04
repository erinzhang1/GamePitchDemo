using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump = new Vector3(0, 1, 0);
    public Vector3 move = new Vector3(0, 0, 1);
    public const float jumpForce = 3f;
    public const float fanForce = 1f;
    public const float movementSpeed = 5;
    private springControl springControl;

    private bool running = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        springControl = GameObject.FindObjectOfType<springControl>();
    }
    void OnCollisionStay(Collision coll)
    {
        running = true;
        if (coll.gameObject.tag == "Spring")
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            animation animation = coll.gameObject.GetComponent<animation>();
            animation.startAni();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        running = true;
        if (other.gameObject.tag == "Fan")
        {
            float distance = Vector3.Distance(other.gameObject.transform.position, transform.position);
            running = false;
            rb.AddForce(jump * fanForce / distance, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running)
        {
            transform.position += move * Time.deltaTime * movementSpeed;
        }
    }
}
