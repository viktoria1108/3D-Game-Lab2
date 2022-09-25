﻿using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

	public float moveSpeed = 10.0f;
	public float jumpSpeed = 4.0f;
	public float gravity = 9.8f;
	public float terminalVelocity = 100f;

	private CharacterController _charCont;
	private Vector3 _moveDirection = Vector3.zero;


	void Start() {
		_charCont = GetComponent<CharacterController>();
	}

	void Update() {
       
		if(true) {
			HandlePlayerMove();
		} else {
			HandlePlayerInactiveMove();
		}
	}

	private void HandlePlayerMove() {
		
		float deltaX = Input.GetAxis("Horizontal") * moveSpeed;
		float deltaZ = Input.GetAxis("Vertical") * moveSpeed;
		_moveDirection = new Vector3(deltaX, _moveDirection.y, deltaZ);
		
		if (_charCont.isGrounded) {
			if (Input.GetButton("Jump")) {
				_moveDirection.y = jumpSpeed;
			} else {
				_moveDirection.y = 0f;
			}
			
			if(deltaX != 0 || deltaZ != 0) {
				
			}
		} else {
			
		}
		ApplyMovement();
	}

	private void HandlePlayerInactiveMove() {
		_moveDirection = Vector3.zero;
		ApplyMovement();
	}

	private void ApplyMovement() {
		_moveDirection = transform.TransformDirection(_moveDirection);
		
		_moveDirection.y -= this.gravity * Time.deltaTime;
		
		_charCont.Move(_moveDirection * Time.deltaTime);
	}


}
