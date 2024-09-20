using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : ICommand
{
    private IMoveableReceiver receiver;

    public MoveRight(IMoveableReceiver receiver)
    {
        this.receiver = receiver;
    }

    public void Execute()
    {
        receiver.Move(new Vector2(1, 0));
    }
}
