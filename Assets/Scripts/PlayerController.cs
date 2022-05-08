using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public float moveSpeed = 1f;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
	}

	public void OnMove(InputValue input) {
	}

	public void OnJump() {
		Debug.Log("Jumped");
		rb.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
	}
}
