﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed;
    public Vector3 input;
    float pushPower = 2.0f;
    Rigidbody rigidbody;
    // Use this for initialization
    void Start () {

        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
       
        if (rigidbody.velocity.magnitude < moveSpeed) {
            rigidbody.AddForce(input * moveSpeed);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "mo")
        {
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
