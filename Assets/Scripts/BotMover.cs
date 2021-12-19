using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform referance_F;
    public Transform referance_R;
    public Transform referance_L;
    public Transform vaccumeBody;
    public float maxDiatance, torque, waitTime; //rDir, lDir;
    private bool isBlockingFrontB, isBlockingRightB, isBlockingLeftB;
    //public WheelCollider leftWheel, rightWheel;
    public Rigidbody vaccumeBodyRb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isBlockingFront();
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(vaccumeBody.position, 2 * maxDiatance);
        //Gizmos.DrawLine(referance_R.position, referance_R.position + referance_R.forward);
    }
    public void isBlockingFront()
    {
        //forward sensor
        if (Physics.Raycast(referance_F.position, referance_F.position + referance_F.forward, maxDiatance))
        {
            //check for left and right sensors
            //right sensor
            isBlockingRight();
            isBlockingLeft();
            Debug.Log("Front Blocked");
            if (isBlockingRightB == false)
            {
                //turn right
                turnRight();
                //Debug
            }
            //left sensor
            else if (isBlockingLeftB == false)
            {
                //turn left
                turnLeft();
            }
            else if(isBlockingLeftB == true && isBlockingRightB == true)
            {
                //move back
            }
        }
        else
        {
            moveForward();
            //StartCoroutine(addForwardImpulse());
            //moveForward();
            //addForwardImpulse();
            //turnRight();
        }
    }
    public void isBlockingRight()
    {
        //right sensor
        if (Physics.Raycast(referance_R.position, referance_R.position + referance_R.forward, maxDiatance))
        {
            Debug.Log("Right Blocked");
            isBlockingRightB = true;
        }
        else
        {
            isBlockingRightB = false;
        }

    }
    public void isBlockingLeft()
    {
        //left sensor
        if (Physics.Raycast(referance_L.position, referance_L.position + referance_L.forward, maxDiatance))
        {
            Debug.Log("Left Blocked");
            isBlockingLeftB = true;
        }
        else
        {
            isBlockingLeftB = false;
        }
    }
    public void moveForward()
    {
        vaccumeBody.transform.Translate(vaccumeBody.forward * torque, Space.World);
        //vaccumeBodyRb.AddForce(vaccumeBody.transform.forward * torque, ForceMode.Impulse);
        //move forward
       // rDir = lDir = 1f;
       // rightWheel.motorTorque = torque * rDir;
       // leftWheel.motorTorque = torque * lDir;
       //vaccumeBody.transform.
    }
    public void turnRight()
    {
        Debug.Log("Turning Right");
        vaccumeBody.transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
        //float xR = vaccumeBody.transform.localRotation.y;
        //rDir = 1f;
        //lDir = 0f;
        //if(xR)
        //while (xR <= xR + 90)
       // {
       //     rightWheel.motorTorque = torque * rDir;
        //    leftWheel.motorTorque = torque * lDir;
        //}
        //rightWheel.motorTorque = torque * rDir;
        //leftWheel.motorTorque = torque * lDir;
    }
    public void turnLeft()
    {
        vaccumeBody.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
    }
    //private IEnumerator addForwardImpulse()
    //{
   //     Debug.Log("not blocking");
    //    yield return new WaitForSeconds(waitTime);
    //    vaccumeBodyRb.AddForce(vaccumeBody.transform.forward * torque, ForceMode.Impulse);
   // }
}
