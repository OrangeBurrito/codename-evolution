using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventSubscriber : MonoBehaviour {
	private SpriteRenderer playerSpriteRenderer;

	private void Awake() {
		playerSpriteRenderer = GetComponent<SpriteRenderer>();
		BallController.OnBallTriggerEnter += OnBallControllerFunc;
	}

	public void OnBallControllerFunc(Color tint) {
		playerSpriteRenderer.color = tint;
	}
}
