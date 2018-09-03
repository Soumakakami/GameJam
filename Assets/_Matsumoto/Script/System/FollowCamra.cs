using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamra : MonoBehaviour {

	public Transform target;
	public float minHeight;

	// Update is called once per frame
	void FixedUpdate () {

		if(!target) return;

		var pos = transform.position;
		pos.y = Mathf.Max(target.position.y, minHeight);

		transform.position = pos;

	}
}
