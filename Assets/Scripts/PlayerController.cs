using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb;
	private Transform	groundCheck;
	private LayerMask groundLayer;
	private Material playerMaterial;

	private bool isFacingRight;

	private float horizontalInput;
	public float moveSpeed = 5f;
	public float jumpPower = 5f;
	public float fallMultiplier = 2.5f;
	
	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
		groundCheck = this.gameObject.transform.Find("GroundCheck").gameObject.transform;
		groundLayer = LayerMask.GetMask("Ground");
		playerMaterial = GetComponent<Renderer>().material;
	}

	private void FixedUpdate() {
		rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

		// Increase gravity when falling
		if (rb.velocity.y < 0) {
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}

		#region Flip Sprite
		if (!isFacingRight && horizontalInput > 0f) {
			FlipSprite();
		} else if (isFacingRight && horizontalInput < 0f) {
			FlipSprite();
		}
		#endregion
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

	public void Jump(InputAction.CallbackContext context) {
		if (context.performed && IsGrounded()) {
			rb.velocity = new Vector2(rb.velocity.x, jumpPower);
		}

		if (context.canceled && rb.velocity.y > 0f) {
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
		}
	}
}
