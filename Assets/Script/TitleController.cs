using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    public Text clickText;      //クリックしてくださいのテキスト

    bool fadeOut;        //FadeOutしてるかのフラグ
    bool fadeDone;       //FadeOutが完了したらtrue

    [SerializeField,Header("消える秒数")]
    float fadeSpeed;         //消え切る時間

    float alpha;        //TitleとTextのアルファ値
    void SetUp()
    {
        clickText = GameObject.Find("ToClick").GetComponent<Text>();
        fadeDone = false;
        fadeOut = false;
        alpha = 1f;
    }

    /// <summary>
    /// クリックしたときの処理
    /// </summary>
    void ClickController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fadeOut = true;
        }
    }

    /// <summary>
    /// FadeInOut時の処理
    /// </summary>
    void FadeOut()
    {
        if (fadeOut == true)
        {
            alpha -= Time.deltaTime;
            clickText.color = new Color(0,0,0,alpha);
        }

        if (alpha<=0)
        {
            fadeOut = false;
            fadeDone = true;
        }
    }

    /// <summary>
    /// 呼び出せば元の状態に戻る
    /// </summary>
    public void ResetTitle()
    {
        fadeDone = false;
        fadeOut = false;
        alpha = 1f;
        clickText.color = new Color(0, 0, 0,1);
    }

    /// <summary>
    /// FadeDoneを見るだけ
    /// </summary>
    /// <returns></returns>
    public bool FadeDone()
    {
        return fadeDone;
    }

    void Start ()
    {
        SetUp();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ClickController();
        FadeOut();
	}
}
