using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HPDIsplay : MonoBehaviour
{
    public TMP_Text mText;

    private void PlayerHit(object sender, int hp)
    {
        mText.text = "Health Points: " + hp;
    }

    private void Start()
    {
        mText.text = "Health Points: " + 200;
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerHPManager>().PlayerHit += PlayerHit;
    }



}
