using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance = null;

    public enum EnemyType
    {
        Imp,
        Snowman,
        Shark,
        FireNewt,
        Jellyfish,
        Count
    };

    [Tooltip("Imp, Snowman, Shark, Fire, Electric")]
    public GameObject[] m_Enemies;

    public Transform m_EnemyPos1;
    public Transform m_EnemyPos2;

    GameObject m_Enemy1;
    //GameObject m_Enemy2;

    public EnemyType m_EnemyType = EnemyType.Count;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void NewEnemy()
    {
        // Choose what enemy type
        int randomEnemy = Random.Range(0, m_Enemies.Length);
        m_Enemy1 = Instantiate(m_Enemies[randomEnemy], m_EnemyPos1);
        m_EnemyType = (EnemyType)randomEnemy;

        // Choose between 1 or 2
        //int randomAmount = Random.Range(1, 3);
        //if(randomAmount == 2)
        //{
        //    m_Enemy2 = Instantiate(m_Enemies[randomEnemy], m_EnemyPos2);
        //}
    }

    public void EnemyAttack()
    {
        switch (m_EnemyType)
        {
            case EnemyType.Imp:
                // Shooting Star
                Debug.Log("Imp attack!");
                break;
            case EnemyType.Snowman:
                // Freeze
                Debug.Log("Snowman attack!");
                break;
            case EnemyType.Shark:
                // Gravity
                Debug.Log("Shark attack!");
                break;
            case EnemyType.FireNewt:
                // Fireball
                Debug.Log("Newt attack!");
                break;
            case EnemyType.Jellyfish:
                // Electricity
                Debug.Log("Jellyfish attack!");
                break;
            case EnemyType.Count:
                break;
            default:
                break;
        }
    }

    public void PreDeath()
    {
        m_Enemy1.GetComponentInChildren<Animator>().SetTrigger("Death");
    }

    public void Death()
    {
        m_EnemyType = EnemyType.Count;

        if (m_Enemy1 != null)
        {
            DestroyImmediate(m_Enemy1);
            m_Enemy1 = null;
        }

        //DestroyImmediate(m_Enemy2);
        //m_Enemy2 = null;
    }
}
