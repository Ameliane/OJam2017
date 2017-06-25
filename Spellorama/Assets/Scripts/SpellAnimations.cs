using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAnimations : MonoBehaviour
{

    public void SelfDestruct()
    {
        if((!GameManager.Instance.IsEnemySusceptible() || GameManager.Instance.IsShielded()) && !GameManager.Instance.GetGameLost())
            UIManager.Instance.ActivateSpellWheel(true);

        Destroy(gameObject);
    }

    public void HoleFall()
    {
        if(GameManager.Instance.IsEnemySusceptible())
            EnemyManager.Instance.EnemyFall();
    }

    public void EnemySquish()
    {
        if (GameManager.Instance.IsEnemySusceptible())
            EnemyManager.Instance.EnemySquish();
    }

    public void Unshield()
    {
        GameManager.Instance.SetShield(false);
    }

    public void WizardSquish()
    {
        GameManager.Instance.WizardSquish();
    }
}
