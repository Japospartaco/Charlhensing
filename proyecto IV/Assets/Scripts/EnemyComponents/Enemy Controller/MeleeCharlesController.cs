using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCharlesController : AEveryCharlesController
{
    public override void Attack()
    {
        Player.GetComponent<PlayerHPManager>().receiveDmg(enemyType.MeleeAttackDamage);
    }
}
