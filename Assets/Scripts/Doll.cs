using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{

    public Material[] materials;
    public Material gold;
    private MeshRenderer meshRenderer;

    
    // Start is called before the first frame update
    void Start(){
        int idx = UnityEngine.Random.Range(0, 5);
        meshRenderer = GetComponent<MeshRenderer>();
        if(idx == 4){
            meshRenderer.material = gold;
            
        }
        meshRenderer.material = materials[idx];
    }

    void destroy(){
    
        Debug.Log("destroyed " + this.name);
        Rigidbody rigidbody = GetComponent<FixedJoint>().connectedBody;
        Crane crane = rigidbody.gameObject.GetComponent<Crane>();
        Destroy(this.gameObject);
        
        crane.hasCatch = false;
    }
    public void getCaught()
    {
        Invoke("destroy", 3);
    }

}
