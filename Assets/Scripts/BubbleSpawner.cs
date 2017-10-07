using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.XR.iOS;

public class BubbleSpawner : MonoBehaviour
{
	public GameObject bubblePrefab;
    private GameObject currentBubble;
    private UnityARCamera arCamera;
    private float timeStart;

	void OnEnable ()
	{
		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdated;
	}

	void OnDestroy ()
	{
		UnityARSessionNativeInterface.ARFrameUpdatedEvent -= ARFrameUpdated;
	}

    private void Start() {
        // Starts not creating a bubble
        currentBubble = null;
    }

    private void ARFrameUpdated (UnityARCamera arCamera)
	{
		// Y'all we're currently spawning a bubble
		if (currentBubble) {
            Vector3 spawnPosition = GetCameraPosition() + (Camera.main.transform.forward * 0.2f);
            currentBubble.transform.position = spawnPosition;
            float scale = (Mathf.Log(Time.time - timeStart) + 2)/12;
            currentBubble.transform.localScale = new Vector3(scale, scale, scale);
		}
        // else nothing
	}

	private Vector3 GetCameraPosition ()
	{
		Matrix4x4 matrix = new Matrix4x4 ();
		matrix.SetColumn (3, arCamera.worldTransform.column3);
		return UnityARMatrixOps.GetPosition (matrix);
	}

    public void StartSpawn() {
        // Updates bubbles position to .2f units in front of the camera
        Vector3 spawnPosition = GetCameraPosition() + (Camera.main.transform.forward * 0.2f);
        currentBubble = Instantiate(bubblePrefab, spawnPosition, transform.rotation) as GameObject;
        MicrophoneInput.StartRecord(currentBubble.GetComponent<AudioSource>());
        timeStart = Time.time;
    }

    public void EndSpawn() {
        // Triggers bubble release animation, stops updating bubble location
        currentBubble.GetComponent<Bubble>().releaseBubble();
        MicrophoneInput.StopRecord();
        currentBubble = null;
    }
}
