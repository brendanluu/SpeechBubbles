using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float scale = Mathf.Log(3f);
        if (scale > 0) {
            Debug.Log(new Vector3(scale, scale, scale));
        }
	}
}
