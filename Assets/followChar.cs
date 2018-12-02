using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class followChar : MonoBehaviour {

    // target must be player

    public Transform target;
    public float duration;
    public float offset;
    public float speed;
    public float minOffset = 0, maxOffset = 6;

    private void Start()
    {
        ChangeTarget();
    }

    public void ChangeTarget(Transform t)
    {
        target = t;
        //speed = target.gameObject.GetComponent<mainCharControl>().speed;
    }

    public void ChangeTarget()
    {
        try
        {
            //speed = target.gameObject.GetComponent<mainCharControl>().speed;
        }
        catch { }
    }

    private void Update()
    {
        if (target)
        {
            //transform.DOMoveY(target.position.y + offset, duration);
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }

}
