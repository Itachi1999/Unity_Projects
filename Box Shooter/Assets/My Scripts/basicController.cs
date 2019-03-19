using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicController : MonoBehaviour {

    public float moveSpeed = 3.0f;
    public float gravity = 9.81f;

    private CharacterController myController;

	// Use this for initialization
	void Start () {
        myController = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

        Vector3 movement = transform.TransformDirection(movementX + movementZ);

        movement.y -= gravity * Time.deltaTime;

       // Debug.Log("Movement Vector" + movement);

        myController.Move(movement);
		
	}
}
