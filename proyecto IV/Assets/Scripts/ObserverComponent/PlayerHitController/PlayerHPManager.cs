using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHPManager : MonoBehaviour
{
    public int HP = 200;
    public EventHandler<int> PlayerHit;
    public Color ogColor;

    private void Start()
    {
        ogColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IProjectile projectile = other.GetComponent<IProjectile>();

        if (projectile != null)
        {
            receiveDmg(projectile.getDmg());
            Destroy(other.gameObject);
        }
    }

    public int receiveDmg(int dmg)
    {
        HP -= dmg;
        PlayerHit?.Invoke(this, HP);
        StartCoroutine("SwitchColor");
        return HP;
    }

    IEnumerator SwitchColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0.3f);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = ogColor;
    }
    
}
