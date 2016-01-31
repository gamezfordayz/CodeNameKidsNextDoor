using UnityEngine;
using System;
using System.Collections;
using interfaces.command;

public abstract class Command
{
    public abstract void Execute<T>(T actor);
}

public class MoveUpCommand : Command
{
    public override void Execute<T>(T actor)
    {
        if (actor != null)
        {
            var Temp = actor as IMoveUp;
            Temp.MoveUp();
        }   
    }
}

public class MoveDownCommand : Command
{
    public override void Execute<T>(T actor)
    {
        if (actor != null)
        {
            var Temp = actor as IMoveDown;
            Temp.MoveDown();
        }
    }
}

public class MoveLeftCommand : Command
{
    public override void Execute<T>(T actor)
    {
        if (actor != null)
        {
            var Temp = actor as IMoveLeft;
            Temp.MoveLeft();
        }
    }
}

public class MoveRightCommand : Command
{
    public override void Execute<T>(T actor)
    {
        if (actor != null)
        {
            var Temp = actor as IMoveRight;
            Temp.MoveRight();
        }
    }
}