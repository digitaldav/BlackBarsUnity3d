using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private CharacterController CController;

    public float PlayerSpeed = 12f;
    public float Gravity = -9.81f;

    private Vector3 FallVelocity;
    public float JumpHeight = 3f;

    public Transform GroundCheckTransform;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;

    bool isGrounded;

    void Start(){
        CController = GetComponent<CharacterController>();
    }


    void Update() {

        if (CController != null) {

            if(GroundCheckTransform == null) {
                Debug.LogError("<color=red>GameObject <color=blue>" + gameObject.name + "</color> error:  no GroundCheckTranform attached</color>");
                enabled = false;
            }

            //Ground check
            isGrounded = Physics.CheckSphere(GroundCheckTransform.position, GroundDistance, GroundMask);
            if(isGrounded && FallVelocity.y < 0) {
                CController.slopeLimit = 45.0f;
                FallVelocity.y = -2f;
            }

            //Movement x, z
            float HorizontalAxis = Input.GetAxisRaw("Horizontal") ;
            float VerticalAxis = Input.GetAxisRaw("Vertical");

            Vector3 MoveVector = transform.right * HorizontalAxis + transform.forward * VerticalAxis;
            CController.Move(MoveVector.normalized * PlayerSpeed * Time.deltaTime);

            //Jump
            if(Input.GetButtonDown("Jump") && isGrounded) {
                CController.slopeLimit = 91.0f;
                FallVelocity.y = Mathf.Sqrt(JumpHeight * -1f * Gravity);
            }

            //Fall movement
            FallVelocity.y += Gravity * Time.deltaTime;
            CController.Move(FallVelocity * Time.deltaTime);

        } else {
            Debug.LogError("<color=red>GameObject <color=blue>" + gameObject.name + "</color> error:  no CharacterController found</color>");
            enabled = false;
        }
        
    }
}
