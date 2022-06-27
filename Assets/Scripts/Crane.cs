using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;


public class Crane : MonoBehaviour
{
    SpringJoint sj;
    FixedJoint fixedJoint;
    public bool hasCatch = false;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void FixedUpdate()
    {
        
        transform.Translate(new Vector3(0,-3f,0) * Time.fixedDeltaTime);
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1.5f, LayerMask.GetMask("Doll")) && !hasCatch){
            Debug.Log("hit "+ hit.collider.name);
            GameObject obj = hit.collider.gameObject;
            gameObject.AddComponent<FixedJoint>();
            fixedJoint = GetComponent<FixedJoint>();
            fixedJoint.connectedBody = obj.GetComponent<Rigidbody>();

            hasCatch = true;
            fixedJoint.enableCollision = true;
            Destroy(obj, 3);
            Destroy(fixedJoint,3);

            var path = Path.GetFullPath(".");

            int idx = Int32.Parse(gm.gameData[ UnityEngine.Random.Range(0,gm.gameData.Count) ]);

            gm.UpdateFile(idx);
            Invoke("activate", 3);
            
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.red, Time.fixedDeltaTime);
        
    }

    void activate()
    {
        hasCatch = false;
    }
}
