using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAnimations : MonoBehaviour
{
    
    void Start()
    {

    }
    
    void Update()
    {

    }

    public void SelfDestruct()
    {
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
}
