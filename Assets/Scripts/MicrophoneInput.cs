using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MicrophoneInput : MonoBehaviour {
	public Button record, play;
	private AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
		//record.onClick.AddListener (Record);
	}

	public void Record(){
		print ("recording....");
		audio.clip = Microphone.Start ("Built-in Microphone", true, 10, 44100);
	}

	public void Play() {
		print ("playing...");
		audio.Play ();
	}

}
