using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getParColor : MonoBehaviour {
    public Color c;

    private void Start()
    {
        try
        {
            c = transform.parent.gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<Light>().color = c;
        }
        catch
        {
            print("err");
        }
    }
}
