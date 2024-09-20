using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : ICommand
{
    private IMoveableReceiver receiver;

    public MoveLeft(IMoveableReceiver receiver)
    {
        this.receiver = receiver;
    }

    public void Execute()
    {
        receiver.Move(new Vector2(-1, 0));
    }
}
