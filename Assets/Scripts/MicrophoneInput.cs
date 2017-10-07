using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MicrophoneInput : MonoBehaviour
{
	public Button record, play;
	private AudioSource audio;

	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		//record.onClick.AddListener (Record);
	}

	public void StartRecord ()
	{
		print ("recording....");
		audio.clip = Microphone.Start ("Built-in Microphone", true, 60, 44100);
	}

	public void StopRecord ()
	{

		if (Microphone.IsRecording (null)) {
			print ("Recording Stopped!");
			Microphone.End (null);
		}

	}

	public void Play ()
	{
		print ("playing...");
		audio.Play ();
	}

}
