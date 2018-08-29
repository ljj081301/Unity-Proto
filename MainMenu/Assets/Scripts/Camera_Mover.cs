using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Mover : MonoBehaviour {

    public float xSensitivity = 1.0f;
    public float ySensitivity = 1.0f;

    public Camera cam;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float yRot = Input.GetAxis("Mouse X") * xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * ySensitivity;

        this.transform.localRotation *= Quaternion.Euler(0, yRot, 0);
        cam.transform.localRotation *= Quaternion.Euler(-xRot, 0, 0);
    }
}
