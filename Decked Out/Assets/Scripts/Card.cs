using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Type { Buff, Magic, Physical, Transform, Debuff, Install }
public enum Target { Strongest, First, Last, Random, None };
public enum Abilities { None, Fire, Wind, Poison, Electric }

public class Card : MonoBehaviour
{
    public string Name;

    public int BaseAttack;
    private int actualAttack;

    public float BaseAttackSpeed; // In seconds
    private float actualAttackSpeed; // In seconds

    public int BaseAbility;
    private int actualAbility;
    
    public Abilities Ability;
    private Ability ability;

    public Target Target;
    public Type Type;

    // Bonuses per card upgrade
    public int UpgradeATK;
    public float UpgradeATKS;
    public int UpgradeAbility;

    public void Start()
    {
        actualAbility = BaseAbility;
        actualAttack = BaseAttack;
        actualAttackSpeed = BaseAttackSpeed;
    }

    private void upgradeCard()
    {
        actualAttack += UpgradeATK;
        actualAttackSpeed -= UpgradeATKS;
        actualAbility += UpgradeAbility;
    }

    public string CardAtk()
        => actualAttack.ToString();
    public string CardType()
        => Type.ToString();
    public string CardAtkSpeed()
        => actualAttackSpeed.ToString();
    public string CardTarget()
        => Target.ToString();
    public string CardAbility()
        => Ability.ToString();
    public string CardAbilityDmg()
        => actualAbility.ToString();
}
