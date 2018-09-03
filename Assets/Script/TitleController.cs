using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    Text clickText;         //クリックしてくださいのテキスト
    Image titleImage;          //タイトルのテキスト

    bool fadeDone;          //FadeOutが完了したらtrue

    [SerializeField,Header("消えるまでの秒数")]
    float fadeTime;         //消え切る時間
    float fadeSpeed;        //消える速さ

    float alpha;        //TitleとTextのアルファ値

    /// <summary>
    /// 起動時にして置きたい処理
    /// </summary>
    void SetUp()
    {
        clickText = GameObject.Find("ToClick").GetComponent<Text>();
        titleImage = GameObject.Find("Image").GetComponent<Image>();

        fadeDone = false;

        alpha = 1f;
    }

    /// <summary>
    /// クリックしたときの処理
    /// </summary>
    void ClickController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("GameStart");
        }
    }

    /// <summary>
    /// FadeInOut時の処理
    /// </summary>
    private IEnumerator Sample(float speed)
    {
        while (alpha >= 0)
        {
            alpha -= speed;
            clickText.color = new Color(0, 0, 0, alpha);
            titleImage.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

    }
    private IEnumerator GameStart()
    {
        yield return StartCoroutine(Sample(fadeSpeed));
        GameMaster.Instance.GameStart();
    }

    /// <summary>
    /// 呼び出せば元の状態に戻る
    /// </summary>
    public void ResetTitle()
    {
        fadeDone = false;
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
        fadeSpeed = clickText.color.a / (fadeTime * 60);
    }
	
	void Update ()
    {
        ClickController();
	}
}
