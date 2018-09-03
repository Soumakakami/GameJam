using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamra : MonoBehaviour {

	public Transform target;

	// Update is called once per frame
	void FixedUpdate () {

		if(!target) return;

		var pos = transform.position;
		pos.y = target.position.y;
		transform.position = pos;

	}
}
