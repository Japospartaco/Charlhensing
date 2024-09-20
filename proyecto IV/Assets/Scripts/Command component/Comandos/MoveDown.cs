using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : ICommand
{
    private IMoveableReceiver receiver;

    public MoveDown(IMoveableReceiver receiver)
    {
        this.receiver = receiver;
    }

    public void Execute()
    {
        receiver.Move(new Vector2(0, -1));
    }
}
