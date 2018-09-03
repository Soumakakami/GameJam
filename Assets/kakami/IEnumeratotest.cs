using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IEnumeratotest : MonoBehaviour {
    float alpha = 1;
    private IEnumerator Sample()
    {
        while (alpha >= 0)
        {
            gameObject.GetComponent<Text>().color = new Color(0,0,0,alpha);
            alpha -= 0.01f;
            yield return null;
        }
        yield return null;


    }
    private void Start()
    {
        alpha = gameObject.GetComponent<Text>().color.a;
        StartCoroutine("Sample");

    }

}
