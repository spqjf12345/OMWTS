using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0;
    public float up = 30;
    public float turnSpeed = 540f;

    void FixedUpdate()
    {
        float h = Input.GetAxis ("Horizontal");
        float v = Input.GetAxis ("Vertical");
        transform.Translate (0f, 0f, v* speed * Time.deltaTime);
        transform.Rotate (0f, h * turnSpeed * Time.deltaTime, 0f);
        if (Input.GetKeyDown (KeyCode.Space)) {
            GetComponent<Rigidbody> ().AddForce (Vector3.up * 500); }
            } 
    }
