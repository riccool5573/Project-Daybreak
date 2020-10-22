using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    private Vector3 hitPos;
    [SerializeField]
    private Convert con;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                hitPos = hit.point;
                con.SetHitPos(hitPos);
            }
        }
    }
    //get position of raycast hit on the 2d plane, and then send it to the Convert script

}