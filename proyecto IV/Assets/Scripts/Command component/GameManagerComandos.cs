using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerComandos : MonoBehaviour
{
    public GameObject player;
    public GameObject bolaDuFogo;
    private IMoveableReceiver playerComponent;
    private IMoveableReceiver bolaDuFogoComponent;
    public Animator animator;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
        playerComponent = player.GetComponent<IMoveableReceiver>();
        bolaDuFogoComponent = bolaDuFogo.GetComponent<IMoveableReceiver>();
    }

    private void Update()
    {
        if(!((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))){
            animator.SetBool("Moving", false);
        }else
        {
            animator.SetBool("Moving", true);
        }

        if (Input.GetKey(KeyCode.W))
        {
            ICommand command = new MoveUp(playerComponent);
            command.Execute();
        }
        if (Input.GetKey(KeyCode.A))
        {
            ICommand command = new MoveLeft(playerComponent);
            command.Execute();
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ICommand command = new MoveDown(playerComponent);
            command.Execute();
        }
        if (Input.GetKey(KeyCode.D))
        {
            ICommand command = new MoveRight(playerComponent);
            command.Execute();
            player.transform.localScale = new Vector3(1,1,1);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            ICommand command = new MoveUp(bolaDuFogoComponent);
            command.Execute();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ICommand command = new MoveLeft(bolaDuFogoComponent);
            command.Execute();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ICommand command = new MoveDown(bolaDuFogoComponent);
            command.Execute();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ICommand command = new MoveRight(bolaDuFogoComponent);
            command.Execute();
        }
    }

}
