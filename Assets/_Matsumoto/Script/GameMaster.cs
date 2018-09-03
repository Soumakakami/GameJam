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

	//プロパティ
	public float PlayerHeight { get; set; }

	//イベント
	public event UnityAction OnGameStart;
	public event UnityAction OnGameOver;

	protected override void Init() {
		base.Init();

		state = GameState.Title;
		AudioManager.PlayBGM("tw087");
		StartCoroutine(GameStartWait());
	}

	public void Quit() {
		Application.Quit();
	}

	public void GameStart() {
		Debug.Log("GameStart");
		state = GameState.Game;
		//登録してあるメソッドをすべて実行する
		OnGameStart();
	}

	public void GameOver() {
		Debug.Log("GameOver");
		state = GameState.Result;
		OnGameOver();
		StartCoroutine(GameOverWait());
	}

	public void GameReset() {

		//登録してあるイベントをいったんすべて削除
		OnGameStart = null;
		OnGameOver = null;

		//データのリセット
		PlayerHeight = 0.0f;

		//今いるシーンを読み込み
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
