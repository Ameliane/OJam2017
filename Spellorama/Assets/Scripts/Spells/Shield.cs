using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private void OnEnable()
    {
        GameManager.Instance.SetShield(true);
        Activate(EnemyManager.Instance.m_EnemyType, 1);
        SpellManager.Instance.StartEffect(Spell.SpellType.Shield);
    }

    void Activate(EnemyManager.EnemyType aType, int aNum)
    {

        GameManager.Instance.Shield();

        enabled = false;
    }
    
}
