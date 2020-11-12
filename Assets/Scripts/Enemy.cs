using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Convert
{

    private bool moving;
    private int minStopTime = 3;
    private float stopTime = 0;
    private Vector3 randomPos;

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        if (moving == true)
        {
            if (agent.remainingDistance <= 1)
            {
                moving = false;
            }
        }
        else
        {
            if (stopTime <= 0)
                RandomPosition();

            else
                stopTime -= Time.deltaTime;

        }
    }
    void RandomPosition()
    {
        randomPos.x = ddd.position.x + Random.Range(-10.0f, 10.0f);
        randomPos.z = ddd.position.z + Random.Range(-10.0f, 10.0f);
        moving = true;
        stopTime = minStopTime + Random.Range(0, 5);
        agent.destination = randomPos;
    }
}
