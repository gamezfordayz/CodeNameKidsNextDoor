using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using interfaces.command;
using System;

public class PlayerMovementInput : MonoBehaviour, IMoveUp, IMoveDown, IMoveLeft, IMoveRight
{
    #region Vars
    public List<Vector2> playerMovement = new List<Vector2>();
    Dictionary<KeyCode, Command> keyToCommand = new Dictionary<KeyCode, Command>();

    KeyCode moveUpButton = KeyCode.W;
    KeyCode moveDownButton = KeyCode.S;
    KeyCode moveLeftButton = KeyCode.A;
    KeyCode moveRightButton = KeyCode.D;

    Command moveUpCommand;
    Command moveDownCommand;
    Command moveLeftCommand;
    Command moveRightCommand;

    float playerSpeed = 5.0f;
    
    RaycastMovement unitMovement;
    #endregion

    #region Methods
    void Start ()
    {
        moveUpCommand = new MoveUpCommand();
        moveDownCommand = new MoveDownCommand();
        moveLeftCommand = new MoveLeftCommand();
        moveRightCommand = new MoveRightCommand();

        keyToCommand.Add(moveUpButton, moveUpCommand);
        keyToCommand.Add(moveDownButton, moveDownCommand);
        keyToCommand.Add(moveLeftButton, moveLeftCommand);
        keyToCommand.Add(moveRightButton, moveRightCommand);

        unitMovement = this.gameObject.GetComponent<RaycastMovement>();
        unitMovement.speed = playerSpeed;
	}
	
	void Update ()
    {
        playerMovement.Clear();

        foreach (KeyValuePair<KeyCode, Command> entry in keyToCommand)
        {
            if (Input.GetKey(entry.Key))
                entry.Value.Execute(this);
        }

        unitMovement.movementVectors = playerMovement;
    }

 
    public void MoveUp()
    {
        playerMovement.Add(Vector2.up);
    }

    public void MoveDown()
    {
        playerMovement.Add(Vector2.down);
    }

    public void MoveLeft()
    {
        playerMovement.Add(Vector2.left);
    }

    public void MoveRight()
    {
        playerMovement.Add(Vector2.right);
    }
    #endregion
}
