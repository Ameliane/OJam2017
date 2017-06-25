using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{

    private void OnEnable()
    {
        Activate(EnemyManager.Instance.m_EnemyType, 1);
        SpellManager.Instance.StartEffect(Spell.SpellType.Electricity);
    }

    void Activate(EnemyManager.EnemyType aType, int aNum)
    {

        switch (aType)
        {
            case EnemyManager.EnemyType.Imp:
                AttackImp(aNum);
                break;
            case EnemyManager.EnemyType.Snowman:
                AttackSnowman(aNum);
                break;
            case EnemyManager.EnemyType.Shark:
                AttackShark(aNum);
                break;
            case EnemyManager.EnemyType.FireNewt:
                AttackFireNewt(aNum);
                break;
            case EnemyManager.EnemyType.Jellyfish:
                AttackJellyfish(aNum);
                break;

            default:
                break;
        }

        enabled = false;
    }

    void AttackImp(int aNum)
    {
        GameManager.Instance.Lose();
    }

    void AttackSnowman(int aNum)
    {
        GameManager.Instance.Win();
    }

    void AttackShark(int aNum)
    {
        GameManager.Instance.Win();
    }

    void AttackFireNewt(int aNum)
    {
        GameManager.Instance.Win();
    }

    void AttackJellyfish(int aNum)
    {
        GameManager.Instance.Lose();
    }

}
