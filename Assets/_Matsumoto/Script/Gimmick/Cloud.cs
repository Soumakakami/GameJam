using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public float attenuation = 0.1f;
	public string playSEName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag != "Player") return;

		other.GetComponent<Rigidbody2D>()
			.velocity *= (1 - attenuation);

		AudioManager.PlaySE(playSEName);
	}
}
