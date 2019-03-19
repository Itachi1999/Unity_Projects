using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour {

    public float spinSpeed = 180.0f;
    public float MotionMagnitude = 0.1f;

    public enum MotionState {Horizontal, Spin, Vertical };
    public MotionState MotionDirections = MotionState.Horizontal;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (MotionDirections)
        {
            case MotionState.Spin:
                gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
                break;

            case MotionState.Horizontal:
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * MotionMagnitude);
                break;

            case MotionState.Vertical:
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * MotionMagnitude);
                break;

        }
	}
}
