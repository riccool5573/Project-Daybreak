using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Convert : MonoBehaviour
{
    /*I've looked at doing this via something like A* or other algorithms, but decided
     that making my own algorithm is beyond the scope of this project. as such this solution is here*/
    private Transform dd; //unity doesnt like me using 2d and 3d as variable names
    private Transform ddd;
    private Transform center2; //center2d and center3d
    private Transform center3;
    private Vector3 diff; //Difference in position between the 3d pathfinder and 3d center
    private Vector3 hitPos; //position where was clicked
    private Vector3 hittDiff; // the difference between the hitpos and center2d
    private Vector3 hitPos3; // hitpos but translated to be on the 3d plane
    [SerializeField] 
    private NavMeshAgent agent;



    void Start()
    {
        dd = GameObject.Find("2d").transform; //get locations of the 2d marker and the 3d pathfinder
        ddd = GameObject.Find("3d").transform;
        center2 = GameObject.Find("center2d").transform; //get locations of center2 and 3
        center3 = GameObject.Find("center3d").transform;
    }

    void Update()
    {
        /*get the location where was clicked on the 2d plane, and convert that to the location
        on the 3d plane and then set the pathfinder to go there */
        hittDiff = hitPos - center2.position;
        hitPos3 = center3.position + hittDiff;
        agent.destination = hitPos3;

        diff = ddd.position - center3.position; //get the location of pathfinder on the map
        dd.position = center2.position + diff; // set the location of the 2d marker to the location of the pathfinder



    }
    public void SetHitPos(Vector3 pos)
    {
        hitPos = pos;
    }
}
