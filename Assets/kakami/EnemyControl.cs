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

    [SerializeField, Header("距離")]
    float distance=4;               //距離

    Vector2 fastPos;                //始まった時の位置

    void EnemyMove()
    {
        switch (modeChange)
        {
            case true:
                switch (moveChangeLeftRight)
                {
                    case true:
                        transform.position += new Vector3(speed, 0, 0);
                        if (transform.position.x >= distance || transform.position.x <= -distance)
                        {
                            moveChangeLeftRight = false;
                        }
                        break;

                    case false:
                        transform.position += new Vector3(speed * -1, 0, 0);
                        if (transform.position.x >= distance || transform.position.x <= -distance)
                        {
                            moveChangeLeftRight = true;
                        }
                        break;
                }
                break;

            case false:
                transform.position += new Vector3(speed, 0, 0);
                if (transform.position.x >= distance || transform.position.x <= -distance)
                {
                    transform.position = fastPos;
                }

                break;
        }
    }

	void Start ()
    {
        fastPos = transform.position;
	}
	

	void Update ()
    {
        EnemyMove();
	}
}
