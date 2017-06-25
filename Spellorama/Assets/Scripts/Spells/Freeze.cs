using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(Effect_cr());
        UIManager.Instance.ActivateSpellWheel(false);
    }

    void Activate(EnemyManager.EnemyType aType, int aNum)
    {

        Debug.Log("Activating Freeze Spell");

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

    private IEnumerator Effect_cr()
    {

        float t = 0;
        while (t < SpellManager.Instance.m_EffecTime / 2)
        {
            t += Time.deltaTime;
            yield return null;
        }

        Activate(EnemyManager.Instance.m_EnemyType, 1);
        yield return null;

        while (t < SpellManager.Instance.m_EffecTime)
        {
            t += Time.deltaTime;
            yield return null;
        }

        enabled = false;
    }

}
