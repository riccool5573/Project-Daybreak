using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Convert : MonoBehaviour
{
    /*I've looked at doing this via something like A* or other algorithms, but decided
     that making my own algorithm is beyond the scope of this project. as such this solution is here*/
    [SerializeField]
    private Transform dd; //unity doesnt like me using 2d and 3d as variable names
    [SerializeField]
    private Transform ddd; // the 2d marker and the 3d pathfinder
    private Transform center2; //center2d and center3d
    private Transform center3;
    private Vector3 diff; //Difference in position between the 3d pathfinder and 3d center
    private Vector3 hitPos; //position where was clicked
    private Vector3 hittDiff; // the difference between the hitpos and center2d
    private Vector3 hitPos3; // hitpos but translated to be on the 3d plane
    [SerializeField]
    private NavMeshAgent agent;
    private bool Selected;
    private Vector3 selectionRange;


    void Start()
    {
        center2 = GameObject.Find("center2d").transform; //get locations of center2 and 3
        center3 = GameObject.Find("center3d").transform;
        selectionRange = new Vector3(0.7f, 0.7f, 0.7f) ;
    }

    void Update()
    {


        diff = ddd.position - center3.position; //get the location of pathfinder on the map
        dd.position = center2.position + diff; // set the location of the 2d marker to the location of the pathfinder

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                hitPos = hit.point;
                if (Selected)
                {
                    /*get the location where was clicked on the 2d plane, and convert that to the location
                      on the 3d plane and then set the pathfinder to go there */
                    hittDiff = hitPos - center2.position;
                    hitPos3 = center3.position + hittDiff;
                    agent.destination = hitPos3;
                    Selected = false;
                }
                
                else if (hit.point.x - this.transform.position.x <= selectionRange.x && hit.point.x - this.transform.position.x >= -selectionRange.x && hit.point.z - this.transform.position.z <= selectionRange.z && hit.point.z - this.transform.position.z >= -selectionRange.z)
                {
                    Debug.Log("Selected");
                    Selected = true;
                }
                
                
            }
        }
    

}

}

