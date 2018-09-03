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
	public int PlayerBoundCount { get; set; }

	//イベント
	public event UnityAction OnGameStart;
	public event UnityAction OnGameOver;

	protected override void Init() {
		base.Init();

		state = GameState.Title;
		AudioManager.PlayBGM("tw087");
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
	}

	public void GameReset() {

		//登録してあるイベントをいったんすべて削除
		OnGameStart = null;
		OnGameOver = null;

		//データのリセット
		PlayerBoundCount = 0;

		//今いるシーンを読み込み
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
