using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Convert : MonoBehaviour
{
    /*i know it'd probably be better if i'd make a 2d pathfinding algorithm of my own 
    but for now this will have to suffice */
    private Transform dd; //unity doesnt like me using 2d and 3d as variable names
    private Transform ddd;
    private Transform center2; //center2d and center3d
    private Transform center3;
    private Vector3 diff; //Difference in position between the 3d pathfinder and 3d center
    private Vector3 hitPos;
    private Vector3 hittDiff;
    private Vector3 hitPos3;
    [SerializeField] 
    private NavMeshAgent agent;



    void Start()
    {
        dd = GameObject.Find("2d").transform; //get locations of the 2d marker and the 3d pathfinder
        ddd = GameObject.Find("3d").transform;
        center2 = GameObject.Find("center2d").transform; //get locations of center2 and 3
        center3 = GameObject.Find("center3d").transform;
    }

    // Update is called once per frame
    void Update()
    {
        diff = ddd.position - center3.position;
        dd.position = center2.position + diff;

        hittDiff = hitPos - center2.position;
        hitPos3 = center3.position + hittDiff;
        agent.destination = hitPos3;

    }
    public void SetHitPos(Vector3 pos)
    {
        hitPos = pos;
    }
}
