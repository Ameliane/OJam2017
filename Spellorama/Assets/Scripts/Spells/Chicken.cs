using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnEnable()
    {
        Activate(EnemyManager.EnemyType.Imp, 1);
    }

    void Activate(EnemyManager.EnemyType aType, int aNum)
    {

        Debug.Log("Activating Chicken Spell");

        switch (aType)
        {
            case EnemyManager.EnemyType.Imp:
                AttackImp(aNum);
                break;
            case EnemyManager.EnemyType.Fire:
                AttackFire(aNum);
                break;
            case EnemyManager.EnemyType.Snowman:
                AttackIce(aNum);
                break;
            case EnemyManager.EnemyType.Electric:
                AttackElectric(aNum);
                break;
            case EnemyManager.EnemyType.Shark:
                AttackSpace(aNum);
                break;
            default:
                break;
        }

        enabled = false;
    }

    void AttackImp(int aNum)
    {
        EnemyManager.Instance.Death();
        GameManager.Instance.Win();
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
