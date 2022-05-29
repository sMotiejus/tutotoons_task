using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCanvasSize : MonoBehaviour
{
    public static float scaleBack;
    private float h = 1920f, w = 1080f,x=1f,y=1f;
    private GameObject canvasObject;
    private RectTransform canvasTransform;
    private RectTransform thisTransform;
    public static bool changed;

    void Start()
    {
        canvasObject = GameObject.FindGameObjectWithTag("BG");
        canvasTransform = canvasObject.GetComponent(typeof(RectTransform)) as RectTransform;
        thisTransform = GetComponent(typeof(RectTransform)) as RectTransform;
        changed = false;
    }

    void Update()
    {
        float wn = canvasTransform.rect.width;
        float hn = canvasTransform.rect.height;
        float scalew = canvasTransform.transform.localScale.x;
        float scaleh = canvasTransform.transform.localScale.y;
        if (wn != w || hn != h || scalew != x || scaleh != y)
        {
            SetRect( hn,scaleh);
            w = wn;
            h = hn;
            x = scalew;
            y = scaleh;
            scaleBack = scaleh;
            changed = true;
        }
    }

    void SetRect(float cheight, float scaley)
    {
        float minusSize = cheight - 100;
        thisTransform.sizeDelta = new Vector2(minusSize, minusSize);
        //transform.localScale = new Vector2(scaley,scaley);
    }
}//class
