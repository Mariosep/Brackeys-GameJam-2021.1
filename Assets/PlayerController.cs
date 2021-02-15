using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public GameObject hitFloorParticles;
    
    private NavMeshAgent navMesh;

    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        MakeRaycast();
    }

    void MakeRaycast(){
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(ray,out hit,1000)){
                //Debug.Log(hit.point);
                navMesh.destination = hit.point;
                Destroy(Instantiate(hitFloorParticles,hit.point, Quaternion.Euler(new Vector3(-90, 0, 0))),2f);
            }
        }
    }
}
