using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float movePower = 5f;
	Rigidbody2D rig;

	bool freeze = false;
	public bool Freeze {
		get {
			return freeze;
		}
		set {
			freeze = value;
			rig.simulated = !value;
		}
	}

	// Use this for initialization
	void Awake () {
		rig = GetComponent<Rigidbody2D>();
		Freeze = true;

		//ゲームのタイミングで止まったり止まらなかったりする
		GameMaster.Instance.OnGameStart += () => Freeze = false;
		GameMaster.Instance.OnGameOver += () => Freeze = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MoveUpdate();
	}

	void MoveUpdate() {

		rig.AddForce(new Vector2(Input.GetAxisRaw("Horizontal") * movePower, 0));

		GameMaster.Instance.PlayerHeight = transform.position.y;
	}
}
