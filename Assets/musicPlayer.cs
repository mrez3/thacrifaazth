using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour {

    public static GameObject instance;

    public GameObject mp;
    
	void Start () {

        if (!instance)
        {

            instance = Instantiate(mp, this.transform);
            DontDestroyOnLoad(this);

        }

	}

}
