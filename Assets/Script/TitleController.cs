using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

    Text clickText;      //クリックしてくださいのテキスト

    bool fadeDone;       //FadeOutが完了したらtrue

    [SerializeField,Header("消えるまでの秒数")]
    float fadeSpeed;         //消え切る時間

    float alpha;        //TitleとTextのアルファ値
    void SetUp()
    {
        clickText = GameObject.Find("ToClick").GetComponent<Text>();
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
            StartCoroutine("Sample",fadeSpeed);
        }
    }

    /// <summary>
    /// FadeInOut時の処理
    /// </summary>
    private IEnumerator Sample(float speed)
    {
        while (alpha >= 0)
        {
            alpha -= 0.01f;
            clickText.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return null;
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
	}
	
	void Update ()
    {
        ClickController();
	}
}
