using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 jump = new Vector3(0, 1, 0);
    public Vector3 move = new Vector3(0, 0, 1);
    public const float jumpForce = 5.5f;
    public const float jumpForceSmall = 3f;
    public const float movementSpeed = 8;
    private springControl springControl;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        springControl = GameObject.FindObjectOfType<springControl>();
    }
    void OnCollisionStay(Collision coll)
    {
        springControl.removePlatform();
        if (coll.gameObject.tag == "Spring")
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            animation animation = coll.gameObject.GetComponent<animation>();
            animation.startAni();
        }
        if (coll.gameObject.tag == "SpringSmall")
        {
            rb.AddForce(jump * jumpForceSmall, ForceMode.Impulse);
            animation animation = coll.gameObject.GetComponent<animation>();
            animation.startAni();
        }
        if (coll.gameObject.tag == "addNew")
        {
            springControl.setPlatform(coll.gameObject);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += move * Time.deltaTime * movementSpeed;
    }
}
