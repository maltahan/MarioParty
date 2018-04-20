using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour {

    public float moveSpeed;
    public Vector3 input;
    Rigidbody rigidbody;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxisRaw("newHorizontal"), 0, Input.GetAxisRaw("newVertical"));
        
        if (rigidbody.velocity.magnitude < moveSpeed)
        {
            rigidbody.AddForce(input * moveSpeed);
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "mo") {
            // how much the character should be knocked back
            var magnitude = 5000;
            // calculate force vector
            var force = transform.position - c.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        }
        
    }
    }

