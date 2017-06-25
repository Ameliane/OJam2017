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
    public GameObject[] m_Attacks;

    public Transform m_EnemyPos;

    GameObject m_Enemy;

    [HideInInspector]
    public EnemyType m_EnemyType = EnemyType.Count;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void NewEnemy()
    {
        // Choose what enemy type
        int randomEnemy = Random.Range(0, m_Enemies.Length);
        m_Enemy = Instantiate(m_Enemies[randomEnemy], m_EnemyPos);
        m_EnemyType = (EnemyType)randomEnemy;
    }

    public void EnemyAttack()
    {
        if (GameManager.Instance.IsShielded())
            return;

        switch (m_EnemyType)
        {
            case EnemyType.Imp:
                // Shooting Star
                GameObject.Instantiate(m_Attacks[(int)m_EnemyType]);
                break;
            case EnemyType.Snowman:
                // Freeze
                GameObject.Instantiate(m_Attacks[(int)m_EnemyType]);
                break;
            case EnemyType.Shark:
                // Gravity
                GameObject.Instantiate(m_Attacks[(int)m_EnemyType]);
                break;
            case EnemyType.FireNewt:
                // Fireball
                GameObject.Instantiate(m_Attacks[(int)m_EnemyType]);
                break;
            case EnemyType.Jellyfish:
                // Electricity
                GameObject.Instantiate(m_Attacks[(int)m_EnemyType]);
                break;
            case EnemyType.Count:
                break;
            default:
                break;
        }
    }

    public void PreDeath()
    {
        m_Enemy.GetComponentInChildren<Animator>().SetTrigger("Death");
    }

    public void Death()
    {
        m_EnemyType = EnemyType.Count;

        if (m_Enemy != null)
        {
            DestroyImmediate(m_Enemy);
            m_Enemy = null;
        }

        //DestroyImmediate(m_Enemy2);
        //m_Enemy2 = null;
    }

    public void EnemyFall()
    {
        StartCoroutine(EnemyFallSequence_cr());
    }

    private IEnumerator EnemyFallSequence_cr()
    {
        float t = 0;
        Vector2 start = m_Enemy.transform.position;
        Vector2 end = m_Enemy.transform.position + new Vector3(0, -10, 0);
        while (t < 2)
        {
            m_Enemy.transform.position = Vector3.Lerp(start, end, t / 2);
            t += Time.deltaTime;
            yield return null;
        }
    }

    public void EnemySquish()
    {
        StartCoroutine(EnemySquishSequence_cr());
    }

    private IEnumerator EnemySquishSequence_cr()
    {
        float t = 0;
        Vector2 fullSize = m_Enemy.transform.localScale;
        Vector2 tinySize = new Vector2(m_Enemy.transform.localScale.x, 0);
        while (t < 2)
        {
            m_Enemy.transform.localScale = Vector3.Lerp(fullSize, tinySize, t / 2);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
