using UnityEngine;

[CreateAssetMenu(fileName = "FlyWeightEnemy", menuName = "Enemy", order = 0)]
public class FlyWeightEnemy : ScriptableObject
{
    public string Type;
    public int MaxHP;
    public float Speed;
    public int MeleeAttackDamage;
    public int ContactDmg;
    public float Range;
}

