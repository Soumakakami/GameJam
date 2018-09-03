using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

	public float power = 1;
	public string playSEName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other) {

		if(other.collider.tag != "Player") return;

		var point = other.contacts[0].point;
		var vec = ((Vector2)other.transform.position - point).normalized;
		other.rigidbody.AddForce(vec * power);

		AudioManager.PlaySE(playSEName);
	}
}
