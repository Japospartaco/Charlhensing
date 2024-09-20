using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : ICommand
{
    private IMoveableReceiver receiver;

    public MoveUp(IMoveableReceiver receiver)
    {
        this.receiver = receiver;
    }

    public void Execute()
    {
        receiver.Move(new Vector2(0,1));
    }
}
