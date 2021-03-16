using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRace : MonoBehaviour
{
    public LayerMask playerCollision;

    public EdgeCollider2D playerCollider1;
    public CircleCollider2D playerCollider2;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider1);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider2);

        Physics2D.IgnoreLayerCollision(playerCollision, playerCollision);
    }
}
