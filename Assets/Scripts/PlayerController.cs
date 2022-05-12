using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	private Transform	groundCheck;
	private LayerMask groundLayer;

	public float moveSpeed = 1f;
	private float horizontalInput;

	private bool isFacingRight;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		groundCheck = this.gameObject.transform.Find("GroundCheck").gameObject.transform;
		// groundLayer = LayerMask.GetMask("Ground");
	}

	void Update() {
		rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

		if (!isFacingRight && horizontalInput > 0f) {
			FlipSprite();
		} else if (isFacingRight && horizontalInput < 0f) {
			FlipSprite();
		}
	}

	private void FlipSprite() {
		isFacingRight = !isFacingRight;
		Vector3 localScale = transform.localScale;

		localScale.x *= -1.0f;
		transform.localScale = localScale;
	}

	// Ground
	private bool IsGrounded() {
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}

	// Movement
	public void Move(InputAction.CallbackContext context) {
		horizontalInput = context.ReadValue<Vector2>().x;
	}

	public void Jump() {
		Debug.Log(groundCheck.name);
		rb.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
	}
}
