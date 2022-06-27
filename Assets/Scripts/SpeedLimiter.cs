using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter : MonoBehaviour
{
    public float maxVelocityX, maxVelocityY, maxVelocityZ;

    public float maxAngleX, maxAngleY, maxAngleZ;
    Rigidbody rigid;
void limitMoveSpeed() {

        Vector3 angular = rigid.angularVelocity;
        Vector3 velocity = rigid.velocity;

        if(angular.x > maxAngleX){
            rigid.angularVelocity = new Vector3(maxAngleX, angular.y, angular.z);
        }

        if(angular.x < maxAngleX * -1){
            rigid.angularVelocity = new Vector3(maxAngleX * -1, angular.y, angular.z);
        }

        if(angular.y > maxAngleY){
            rigid.angularVelocity = new Vector3(angular.x, maxAngleY, angular.z);
        }

        if(angular.y < maxAngleY * -1){
            rigid.angularVelocity = new Vector3(angular.x, maxAngleY * -1, angular.z);
        }

        if(angular.z > maxAngleZ){
            rigid.angularVelocity = new Vector3(angular.x, angular.y, maxAngleZ);
        }

        if(angular.z < maxAngleZ * -1){
            rigid.angularVelocity = new Vector3(angular.x , angular.y, maxAngleZ * -1);
        }

        if (velocity.x > maxVelocityX)
        {
            rigid.velocity = new Vector3(maxVelocityX, velocity.y, velocity.z);
        }
        if (velocity.x < (maxVelocityX * -1))
        {
            rigid.velocity = new Vector3((maxVelocityX * -1), velocity.y, velocity.z);
        }

         if (velocity.y > maxVelocityY)
        {
            rigid.velocity = new Vector3(velocity.x, maxVelocityY, velocity.z);
        }
        if (velocity.y < (maxVelocityY * -1))
        {
            rigid.velocity = new Vector3(velocity.x, (maxVelocityY * -1), velocity.z);
        }

        if (velocity.z > maxVelocityZ)
        {
            rigid.velocity = new Vector3(velocity.x, velocity.y, maxVelocityZ);
        }
        if (velocity.z < (maxVelocityZ * -1))
        {
            rigid.velocity = new Vector3(velocity.x, velocity.y, (maxVelocityZ * -1));
        }
    }

    void limitArea() {

        Vector3 pos = transform.position;

        if(pos.y > 12){
            transform.position = new Vector3(pos.x, 10, pos.z);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
    rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        limitArea();
        limitMoveSpeed();
    }
}
