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
        // how much the character should be knocked back
        if (c.gameObject.tag == "mo1")
        {
            var magnitude = 0f;
            // calculate force vector
            var force = (transform.position - c.transform.position);
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            //c.gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            //gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            var other = c.rigidbody.velocity.magnitude;
            var me = rigidbody.velocity.magnitude;
            if (other > me)
            {
                magnitude = c.rigidbody.velocity.magnitude * 1000;
                gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            }
            else {
                magnitude = rigidbody.velocity.magnitude * 1000;
                gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            }
            //gameObject.GetComponent<Rigidbody>().AddForce(c.rigidbody.velocity * magnitude);
            //Vector3 forceVec = -this.rigidbody.velocity.normalized * magnitude;
            //c.rigidbody.AddForce(forceVec, ForceMode.Acceleration);
        }
        //else if (gameObject.tag == "mo") {
        //    c.gameObject.GetComponent<Rigidbody>().AddForce(this.rigidbody.velocity * magnitude);
        //}
        if (c.gameObject.tag == "water") {
            ScoreCounter.ScoreValue += 10;
        }

    }

}
