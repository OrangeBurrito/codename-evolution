using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public Transform target;
	public Vector3 offset = new Vector3(0, 2, -1);

	void LateUpdate() {
		transform.position = target.position + offset;
	}
}