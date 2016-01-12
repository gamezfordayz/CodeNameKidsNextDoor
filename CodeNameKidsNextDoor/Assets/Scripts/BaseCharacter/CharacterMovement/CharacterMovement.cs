using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{
    #region Vars
    const float skinWidth = 0.05f;

    int horizontalRayCount = 10;
    int verticalRayCount = 10;

    float horizontalRaySpacing, verticalRaySpacing;
    float speed = 5.0f;

    Vector2 playerVelocity;

    public LayerMask collisionMask;
    BoxCollider2D playerCollider;
    RaycastOrigins raycastOrigins;
    #endregion

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight, bottomLeft, bottomRight;
    }

    void Awake ()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }

    void Update()
    {
        MovePlayer();
        UpdateRaycastOrigins();
    }

    #region Methods
    //Calculates the spacing of the Rays to dynamically space the ray casts proportionally
    void CalculateRaySpacing()
    {
        Bounds bounds = playerCollider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    //Updates the Raycast Origins on the collider based on the bounds and skin width
    void UpdateRaycastOrigins()
    {
        Bounds bounds = playerCollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    //Move player with transform.translate based on raycast collision and 'WASD' movement
    void MovePlayer()
    {
        playerVelocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            playerVelocity += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerVelocity += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerVelocity += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerVelocity += Vector2.right;
        }

        VerticalCollisions();
        HorizontalCollisions();
        

        transform.Translate(playerVelocity * Time.deltaTime * speed);
    }

    //Calculates vertical collisions by shooting out rays and calculating distance
    void VerticalCollisions()
    {
        //find direction player is moving
        float directionY = Mathf.Sign(playerVelocity.y);
        float rayLegnth = Mathf.Abs(playerVelocity.y) + skinWidth;

        //go through all rays
        for (int i = 0; i < verticalRayCount; i++)
        {
            //find which corner to start with
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLegnth, collisionMask);

            //if it gets too close to a collidable object, stop moving
            if (hit && hit.distance <= skinWidth * 2)
                playerVelocity.y = 0;
        }
    }

    //Calculates horizontal collisions by shooting out rays and calculating distance
    void HorizontalCollisions()
    {
        //find direction player is moving
        float directionX = Mathf.Sign(playerVelocity.x);
        float rayLegnth = Mathf.Abs(playerVelocity.x) + skinWidth;

        //go through all rays
        for (int i = 0; i < horizontalRayCount; i++)
        {
            //find which corner to start with
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);

            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLegnth, collisionMask);

            //if it gets too close to a collidable object, stop moving
            if (hit && hit.distance <= skinWidth * 2)
                playerVelocity.x = 0;
        }
    }
    #endregion
}