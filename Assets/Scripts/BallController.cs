using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	private Color ballTint;
	public static Action<Color> OnBallTriggerEnter = delegate {};

	private void Awake() {
		ballTint = GetComponent<SpriteRenderer>().color;
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		if (!collider.CompareTag("Tilemap")) {
			OnBallTriggerEnter(ballTint);
		}
	}
}


