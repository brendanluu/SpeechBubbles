using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class PaintManager : MonoBehaviour {

	public GameObject cubeObj;

	private Vector3 previousPosition;

	void OnEnable() {
		UnityARSessionNativeInterface.ARFrameUpdatedEvent += ARFrameUpdated;
	}

	void OnDestroy() {
		UnityARSessionNativeInterface.ARFrameUpdatedEvent -= ARFrameUpdated;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

		private void ARFrameUpdated(UnityARCamera arCamera) {
		Vector3 paintPosition = GetCameraPosition (arCamera) + (Camera.main.transform.forward * 0.2f);
		if (Vector3.Distance (paintPosition, previousPosition) > 0.025f) {
			Instantiate (cubeObj, paintPosition, transform.rotation);
			previousPosition = paintPosition;
		}
	}

		private Vector3 GetCameraPosition(UnityARCamera cam) {
			Matrix4x4 matrix = new Matrix4x4 ();
			matrix.SetColumn (3, cam.worldTransform.column3);
			return UnityARMatrixOps.GetPosition (matrix);
		}
		
}
