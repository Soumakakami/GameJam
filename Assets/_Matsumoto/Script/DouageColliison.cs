using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DouageColliison : MonoBehaviour {


	private void OnCollisionEnter2D(Collision2D other) {

		if(other.collider.tag != "Player") return;

		GameMaster.Instance.PlayerBoundCount++;
		AudioManager.PlaySE("jump-anime1");

	}
}
