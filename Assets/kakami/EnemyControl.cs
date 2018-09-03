using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    [SerializeField, Header("敵の動き(左右)")]
    bool moveChangeLeftRight;        //敵の左右の動きを変える

    [SerializeField, Header("敵の行動")]
    bool modeChange;                //敵の動きを変える

    [SerializeField,Header("速度")]
    float speed;                    //敵の速度



    void EnemyMove()
    {
        switch (moveChangeLeftRight)
        {
            case true:
                transform.position += new Vector3(speed,0,0);
                break;

            case false:
                transform.position += new Vector3(speed*-1, 0, 0);
                //if (transform.position.x)
                //{

                //}
                break;
        }

        switch (modeChange)
        {
            case true:

                break;

            case false:

                break;
        }
    }

	void Start ()
    {
		
	}
	

	void Update ()
    {
		
	}
}
