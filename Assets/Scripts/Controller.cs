using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody rigid;
    public float speed;
    private Vector3 moveDir;
    public Animator animator;
    public Crane crane;

    bool isPicking = false;
    bool isMoving = false;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        moveDir = Vector3.zero; 
        // animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid == null) return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        moveDir = new Vector3(x, 0, z);
        moveDir *= speed;

        if (Input.GetKey(KeyCode.Space))
        {
            animator.enabled = true;
            animator.SetBool("Pick",true);
            Invoke("moveDown",1);
            Invoke("deactivate",4);
        }
        
    }


    void moveDown() {
        rigid.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        isPicking = true;
        Invoke("moveUp",2f);
    }

    void moveUp(){
    
        isMoving = true;
    
    }


    void deactivate () {
        animator.SetBool("Pick",false);
        isMoving = false;
        isPicking = false;
        rigid.constraints = RigidbodyConstraints.None;
        rigid.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
        
    }

    private void FixedUpdate()
    {

        if(!isPicking && !isMoving){ // picking and moving is all false
            if(transform.position.y <= 9){
                transform.Translate(new Vector3(0,3f,0) * Time.fixedDeltaTime);
                return;
            }
             else if (transform.position.y > 9){
                transform.Translate(new Vector3(0,-3f,0) * Time.fixedDeltaTime);
            }

            if(!animator.GetBool("Pick")){
                rigid.velocity = moveDir;
            } 
        } else if (!isMoving){    // picking is true, moving is false
            if(!crane.hasCatch){
            transform.Translate(new Vector3(0,-3f,0) * Time.fixedDeltaTime);
            }
        } else { // picking is t or false, moving is true
            if(transform.position.y <= 9){
            transform.Translate(new Vector3(0,3f,0) * Time.fixedDeltaTime);
            } 
        }
    }
}

