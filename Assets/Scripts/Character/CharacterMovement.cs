using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CharacterMovement : MonoBehaviour
{
    [Header ("MOVEMENT VARIABLES")]
    [Space(10)]
    [Header("Movement")]
    [Range(0f, 300f)]
    public float speed;
    public float jumpSpeed;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * Time.deltaTime;

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
