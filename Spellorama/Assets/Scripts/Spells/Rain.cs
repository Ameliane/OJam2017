using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
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
    }

    void Activate(EnemyManager.EnemyType aType, int aNum)
    {

        Debug.Log("Activating Rain Spell");

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
        GameManager.Instance.Win();
        Debug.Log("Against Shark");
    }

    void AttackFireNewt(int aNum)
    {
        GameManager.Instance.Win();
        Debug.Log("Against Newt");
    }

    void AttackJellyfish(int aNum)
    {
        GameManager.Instance.Win();
        Debug.Log("Against Jellyfish");
    }

}
