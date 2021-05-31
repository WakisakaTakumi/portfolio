using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    //[SerializeField]
    float SPEED;
    private Rigidbody2D rigidBody;
    private Vector2 inputAxis;
    void Start(){
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate(){
     //スプリント   
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SPEED = 4.0f;
        }
        else SPEED = 1.0f;

        rigidBody.velocity = inputAxis.normalized * SPEED;
    }
}

