using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour
{
    public Rigidbody2D Player;

    public GameObject FindClosestRespawn()
    {
        GameObject[] respawn;
        respawn = GameObject.FindGameObjectsWithTag("Respawn");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector2 position = transform.position;


        foreach (GameObject respawns in respawn)
        {
            Vector2 diff = respawns.transform.position - Player.transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance<distance)
            {
                closest = respawns;
                distance = curDistance;
                Player.transform.position = respawns.transform.position;
            }
        }
        return closest;
        }

    private void FixedUpdate()
    {
         if(Player.transform.position.y < -16)
        {
            FindClosestRespawn();
        }

    }
}
