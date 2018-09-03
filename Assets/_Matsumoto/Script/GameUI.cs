using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameUI : MonoBehaviour {

	public GameObject targetPanel;
	public Text distanceText;

	bool isShowUI;

	void Awake() {
		Hide();
		GameMaster.Instance.OnGameStart += Show;
		GameMaster.Instance.OnGameOver += Hide;
	}

	void Update() {

		distanceText.text = GameMaster.Instance.PlayerBoundCount + "回";
	}

	public void Show() {
		targetPanel.SetActive(isShowUI = true);
	}

	public void Hide() {
		targetPanel.SetActive(isShowUI = false);
	}
}
