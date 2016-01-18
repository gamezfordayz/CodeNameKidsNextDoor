using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementInput : MonoBehaviour
{
    #region Vars
    float playerSpeed = 5.0f;

    public List<Vector2> playerMovement = new List<Vector2>();
    
    RaycastMovement unitMovement;
    #endregion

    void Start ()
    {
        unitMovement = this.gameObject.GetComponent<RaycastMovement>();
        unitMovement.speed = playerSpeed;
	}
	
	void Update ()
    {
        playerMovement.Clear();
        //Inputs add vector directions to list
        if (Input.GetKey(KeyCode.W))
            playerMovement.Add(Vector2.up);
        if (Input.GetKey(KeyCode.S))
            playerMovement.Add(Vector2.down);
        if (Input.GetKey(KeyCode.A))
            playerMovement.Add(Vector2.left);
        if (Input.GetKey(KeyCode.D))
            playerMovement.Add(Vector2.right);

        //pass list to the raycastMovement
        unitMovement.movementVectors = playerMovement;
    }
}
