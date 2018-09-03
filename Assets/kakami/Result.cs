using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    GameObject IntermediateObj;

    float score;            //プレイヤーが取得したスコア
    [SerializeField,Header("乗算させる値")]
    float multiplication;   //スコアに乗算する数値

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
        score = GameMaster.Instance.PlayerHeight;
        score = score * multiplication;
        resultText.text = score.ToString("")+"点";
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
