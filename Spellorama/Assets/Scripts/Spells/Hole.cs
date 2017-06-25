using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnEnable()
    {
        Activate(EnemyManager.Instance.m_EnemyType, 1);
        SpellManager.Instance.StartEffect(Spell.SpellType.Hole);
    }

    void Activate(EnemyManager.EnemyType aType, int aNum)
    {

        Debug.Log("Activating Hole Spell");
        SpellManager.Instance.StartEffect(Spell.SpellType.Hole);

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
        GameManager.Instance.Win();
        Debug.Log("Against Imp");
    }

    void AttackSnowman(int aNum)
    {
        GameManager.Instance.Win();
        Debug.Log("Against Snowman");
    }

    void AttackShark(int aNum)
    {
        GameManager.Instance.Lose();
        Debug.Log("Against Shark");
    }

    void AttackFireNewt(int aNum)
    {
        GameManager.Instance.Win();
        Debug.Log("Against Newt");
    }

    void AttackJellyfish(int aNum)
    {
        GameManager.Instance.Lose();
        Debug.Log("Against Jellyfish");
    }

}
