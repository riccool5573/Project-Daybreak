using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Convert
{
    private Vector3 hitPos; //position where was clicked
    private Vector3 hittDiff; // the difference between the hitpos and center2d
    private Vector3 hitPos3; // hitpos but translated to be on the 3d plane
    private bool Selected;
    

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
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
