using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    [SerializeField, Header("敵の動きtrueが右")]
    bool moveChangeLeftRight;        //敵の左右の動きを変える
    [SerializeField, Header("敵の行動trueが行ったり来たり")]
    bool modeChange;                //敵の動きを変える

    [SerializeField,Header("速度")]
    float speed;                    //敵の速度

    float angle=1;

    [SerializeField, Header("ランダムな最高速度")]
    float randomSpeedFast;          //ランダムな最高速度
    [SerializeField, Header("ランダムな最低速度")]
    float randomSpeedSlow;          //ランダムな最低速度

    [SerializeField, Header("距離")]
    float distance=4;               //距離

    [SerializeField, Header("ランダムな最大高さ")]
    float randomHeight;             //ランダムな高さ
    [SerializeField, Header("ランダムな最低高さ")]
    float randomLow;                //ランダムな低さ

    Vector2 fastPos;                //始まった時の位置

    void EnemyMove()
    {


        if (modeChange)
        {
            transform.position += new Vector3(speed, 0, 0)*Time.deltaTime;
            transform.Translate(speed*Time.deltaTime,0,0);
            if (Mathf.Abs(transform.position.x) > distance)
            {
                
                speed = Random.Range(randomSpeedFast, randomSpeedSlow)*angle;
                angle *= -1;

                //Vector3 direction = transform.localScale;
                //direction.x *= -1;
                //transform.localScale = direction;

                transform.position = new Vector2(distance*angle,Random.Range(randomHeight,randomLow));
                
            }
        }
        else
        {
            transform.position += new Vector3(speed,0,0) * Time.deltaTime;
            if (Mathf.Abs(transform.position.x) > distance)
            {

                transform.position = new Vector2(fastPos.x, Random.Range(randomHeight, randomLow));

                speed = Random.Range(randomSpeedFast, randomSpeedSlow);
            }
        }
    }

	void Start ()
    {
        fastPos = transform.position;
        if (moveChangeLeftRight == false)
        {
            speed *= -1;
        }
    }
	
void aaaa()
{

    }
	void Update ()
    {
        EnemyMove();
	}
}
