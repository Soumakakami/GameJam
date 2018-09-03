using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouageColliison : MonoBehaviour {


	private void OnCollisionEnter2D(Collision2D other) {

		if(other.collider.tag == "Player")
			AudioManager.PlaySE("jump-anime1");

	}
}
