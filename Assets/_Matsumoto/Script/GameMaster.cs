using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

enum GameState {
	Title,
	Game,
	Result,
}

public sealed class GameMaster : SingletonMonoBehaviour<GameMaster> {

	GameState state;

	public event UnityAction OnGameStart;
	public event UnityAction OnGameOver;

	protected override void Init() {
		base.Init();

		state = GameState.Title;
		StartCoroutine(GameStartWait());
	}

	public void Quit() {
		Application.Quit();
	}

	public void GameStart() {
		Debug.Log("GameStart");
		state = GameState.Game;
		OnGameStart();
	}

	public void GameOver() {
		Debug.Log("GameOver");
		state = GameState.Result;
		OnGameOver();
		StartCoroutine(GameOverWait());
	}

	public void GameReset() {
		//今いるシーンを読み込み
		OnGameStart = null;
		OnGameOver = null;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		StartCoroutine(GameStartWait());
	}


	IEnumerator GameStartWait() {
		yield return new WaitForSeconds(1f);
		GameStart();
	}

	IEnumerator GameOverWait() {
		yield return new WaitForSeconds(1f);
		GameReset();
	}
}
