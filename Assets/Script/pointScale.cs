using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointScale : MonoBehaviour
{
    private void Start()
    {
        float scale2 = gameObject.transform.parent.gameObject.transform.parent.localScale.y*250;
        float scale = transform.localScale.y ;
        transform.localScale = new Vector2(scale2,scale2);
    }
}
