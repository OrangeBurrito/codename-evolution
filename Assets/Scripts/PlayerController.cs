using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	public float moveSpeed = 1f;
	private float inputX;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);
	}

	public void OnMove(InputValue input) {
		inputX = input.Get<Vector2>().x;
	}

	public void OnJump() {
		Debug.Log("Jumped");
		rb.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
	}
}
