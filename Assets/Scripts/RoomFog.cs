using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFog : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer render;
    private int peopleInRoom;
    // Start is called before the first frame update
    void Start()
    {
        render.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collide");
        if (other.gameObject.tag == "Player")
        {
            render.enabled = true;
            peopleInRoom++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            peopleInRoom--;
            if (peopleInRoom <= 0)
            {
                render.enabled = false;
               if(peopleInRoom < 0)
                {
                    peopleInRoom = 0;
                }
            }
        }
    }
}
