using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRace : MonoBehaviour
{
    public CircleCollider2D Collider1;
    public EdgeCollider2D Collider2;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Collider1);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Collider2);
        Physics2D.IgnoreCollision(GetComponent<EdgeCollider2D>(), Collider1);
        Physics2D.IgnoreCollision(GetComponent<EdgeCollider2D>(), Collider2);

    }
}
