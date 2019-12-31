using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float Sensibility = 100f;

    public Transform PlayerTransform;

    private float RotationXClamp = 0f;

    public float LimitY1 = 90f;
    public float LimitY2 = -90f;

    void Start(){

        Cursor.lockState = CursorLockMode.Locked;

    }

    

    void Update(){

        float XAxis = Input.GetAxis("Mouse X")*Sensibility*Time.deltaTime;
        float YAxis = Input.GetAxis("Mouse Y")*Sensibility*Time.deltaTime;

        RotationXClamp -= YAxis;
        RotationXClamp = Mathf.Clamp(RotationXClamp, LimitY2, LimitY1);
        transform.localRotation = Quaternion.Euler(RotationXClamp, 0f, 0f);

        PlayerTransform.Rotate(Vector3.up * XAxis);
       

    }
}
