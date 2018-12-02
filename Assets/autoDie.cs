using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDie : MonoBehaviour {

    public float duration;

	void Start () {
        Destroy(gameObject, duration);
	}

}
