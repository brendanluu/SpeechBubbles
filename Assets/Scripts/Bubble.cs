using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class Bubble : MonoBehaviour {

    private AudioSource audioSource;
    private Animator anim;
    private BubbleWave wave;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other) {
		Debug.Log("collided");
        if (other.gameObject.name == "CameraCollider") {
            audioSource.Play();
            //wave.playSound();
        }
    }

    private void OnTriggerExit(Collider other) {
		Debug.Log("out");
        if (other.gameObject.name == "CameraCollider") {
            audioSource.Stop();
            //wave.stopSound();
        }
    }

    public void releaseBubble() {
        anim.SetTrigger("release");
    }

    public void SetScale(float scale) {
        if (scale > 0) {
            gameObject.transform.localScale = new Vector3(scale, scale, scale);
        } else {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
