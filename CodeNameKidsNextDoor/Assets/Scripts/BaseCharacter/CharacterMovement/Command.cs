using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Command
{
    public abstract void Execute(GameObject actor);
}

public class MoveUpCommand : Command
{
    public override void Execute(GameObject actor)
    {
        
    }
}