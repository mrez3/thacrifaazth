﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharRun : MonoBehaviour {

    public float speed;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
    }

}
