using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteParallax : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;

    public Vector2 parallaxEffectMultiplier;

    private float textureUnitSizeX;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        
        transform.position -= new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        if(cameraTransform.position.x/parallaxEffectMultiplier.x >= spriteRenderer.size.x)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            //transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
            spriteRenderer.size = new Vector2(spriteRenderer.size.x + 160, spriteRenderer.size.y);
        }
    }
}
