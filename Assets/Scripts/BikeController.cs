using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour {
	[Header("Wheels")]
	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;
	[Header("Chasis params")]
	Rigidbody2D chasis;
	public float speed;
	public float maxSpeed;
	public float rotationSpeed;
	public float maxRotationSpeed;
	public float jumpForce;
	public Transform collisionDetector;
	public float detectorRadius;
	public LayerMask scenarioLayer;
	JointMotor2D backMotor,frontMotor;
	
	float moveBW,moveFW,rotation;
    bool jumped = false;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(collisionDetector.transform.position, detectorRadius);
    }

    void Start () {
		chasis = GetComponent<Rigidbody2D>();
		backMotor = backWheel.motor;
		frontMotor = frontWheel.motor;
	}

    void Update () {
		if(Input.GetKey(KeyCode.D)){
            backWheel.useMotor = true;
            if (moveBW<maxSpeed)
				moveBW+=speed;
			else
				moveBW = maxSpeed;
            backWheel.motor = backMotor;
        }
        else if(Input.GetKey(KeyCode.F)){
            backWheel.useMotor = true;
            if (moveBW>-maxSpeed)
				moveBW-=speed;
			else
				moveBW = -maxSpeed;
            backWheel.motor = backMotor;
        }
        else{
            //moveBW = 0;
            backWheel.useMotor = false;
		}

		if(Input.GetKey(KeyCode.J)){
            frontWheel.useMotor = true;
            if (moveFW < maxSpeed)
				moveFW+=speed;
			else
				moveFW = maxSpeed;
            frontWheel.motor = frontMotor;
        }
        else if(Input.GetKey(KeyCode.K)){
            frontWheel.useMotor = true;
            if (moveFW > -maxSpeed)
				moveFW-=speed;
			else
				moveFW = -maxSpeed;
            frontWheel.motor = frontMotor;
        }
        else{
            //moveFW = 0;
            frontWheel.useMotor = false;
		}

		if(Input.GetKey(KeyCode.S)){
			if(rotation<maxRotationSpeed)
				rotation+= rotationSpeed;
			else
				rotation = maxRotationSpeed;
		}else if(Input.GetKey(KeyCode.L)){
			if(rotation>-maxRotationSpeed)
				rotation-=rotationSpeed;
			else
				rotation = -maxRotationSpeed;
		}else
			rotation = 0;
	}

	void FixedUpdate(){
		backMotor.motorSpeed = moveBW;
		frontMotor.motorSpeed = moveFW;
		
		chasis.AddTorque(rotation);
		if(Input.GetAxisRaw("Jump")!=0){
			if(IsGrounded() && !jumped){
                jumped = true;
                Invoke("ActivateJump", 0.3f);
				chasis.AddForce(Vector3.up * jumpForce);
				Debug.Log("Jumping");
			}
		}
	}

	bool IsGrounded(){
		bool detect = Physics2D.OverlapCircle(collisionDetector.position,detectorRadius,scenarioLayer);
		Debug.Log(detect);
		return detect;
	}

    void ActivateJump()
    {
        jumped = false;
    }
}
