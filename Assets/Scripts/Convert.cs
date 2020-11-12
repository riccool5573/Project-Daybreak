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
    protected Transform ddd; // the 2d marker and the 3d pathfinder
    protected Transform center2; //center2d and center3d
    protected Transform center3;
    private Vector3 diff; //Difference in position between the 3d pathfinder and 3d center
    protected Vector3 selectionRange;
    [SerializeField]
    protected NavMeshAgent agent;



    void Start()
    {
        center2 = GameObject.Find("center2d").transform; //get locations of center2 and 3
        center3 = GameObject.Find("center3d").transform;
        selectionRange = new Vector3(0.7f, 0.7f, 0.7f) ;
    }

    void Update()
    {


      


    }
    protected void UpdatePosition()
    {
        diff = ddd.position - center3.position; //get the location of pathfinder on the map
        dd.position = center2.position + diff; // set the location of the 2d marker to the location of the pathfinder
    }
}

