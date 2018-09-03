using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    GameObject IntermediateObj;

    int score;            //プレイヤーが取得したスコア

    Text resultText;        //resultを表示させるText

    bool test=false;
    // Use this for initialization
    void Start ()
    {
        resultText = GameObject.Find("ResultText").GetComponent<Text>();
        IntermediateObj = GameObject.Find("IntermediateObj");
        IntermediateObj.SetActive(false);
        GameMaster.Instance.OnGameOver+= ResultTextWriting;
    }
    void ResultTextWriting()
    {
        IntermediateObj.SetActive(true);
        score = GameMaster.Instance.PlayerBoundCount;
        resultText.text = score.ToString("")+"回";
        test = true;
    }
    private void Update()
    {
        if (test&&Input.GetMouseButtonDown(0))
        {
            GameMaster.Instance.GameReset();
        }
    }
}
