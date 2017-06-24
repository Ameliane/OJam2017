using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnEnable()
    {
        Activate(Enemy.EnemyType.IMP, 1);
    }

    void Activate(Enemy.EnemyType aType, int aNum)
    {

        Debug.Log("Activating Fireball Spell");

        switch (aType)
        {
            case Enemy.EnemyType.IMP:
                AttackImp(aNum);
                break;
            case Enemy.EnemyType.FIRE:
                AttackFire(aNum);
                break;
            case Enemy.EnemyType.ICE:
                AttackIce(aNum);
                break;
            case Enemy.EnemyType.ELECTRIC:
                AttackElectric(aNum);
                break;
            case Enemy.EnemyType.SPACE:
                AttackSpace(aNum);
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

    void AttackFire(int aNum)
    {

    }

    void AttackIce(int aNum)
    {

    }

    void AttackElectric(int aNum)
    {

    }


    void AttackSpace(int aNum)
    {

    }

}
