using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class Bubble : MonoBehaviour {

    private AudioSource audio;
    private Animator anim;
    private BubbleWave wave;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter(Collider other) {
		Debug.Log("collided");
        if (other.GetComponent<UnityARVideo>()) {
            audio.Play();
            wave.playSound();
        }
    }

    private void OnTriggerExit(Collider other) {
		Debug.Log("out");
        if (other.GetComponent<UnityARVideo>()) {
            audio.Stop();
            wave.stopSound();
        }
    }

    public void releaseBubble() {
        anim.SetTrigger("release");
    }
}
