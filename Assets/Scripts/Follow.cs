using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [Header("Offsets")]
    public float offsetX;
    public float offsetY;

    [Header("Target tag")]
    public string targetTag;

    [Header("Speed to follow")]
    [Range(0, 3)]
    public float followSpeed;

    private Rigidbody2D rb;
    private GameObject Target;

    void Start()
    {
        Target = GameObject.FindWithTag(targetTag);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.transform.position.x + offsetX, Target.transform.position.y +offsetY), followSpeed);
    }
}
