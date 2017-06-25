using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    public Wizard m_Wizard;

    public Transform m_ArrivalPos;
    public Transform m_ExitPos;

    int m_CurrentFloor = 0;
    int m_MaxFloor = 0;

    int m_Life = 3;

    bool m_IsSusceptible = false;

    bool m_IsShielded = false;

    bool m_GameLost = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ReturnMenu();
        }
    }

    public void StartGame()
    {
        EnemyManager.Instance.NewEnemy();
        SpellManager.Instance.ResetAllSpells();
    }

    public void SetShield(bool aShield)
    {
        m_IsShielded = aShield;
    }

    public bool IsShielded()
    {
        return m_IsShielded;
    }

    public bool IsEnemySusceptible()
    {
        return m_IsSusceptible;
    }

    public void Win()
    {
        m_IsSusceptible = true;

        //Move Player
        StartCoroutine(MonsterDeathSequence_cr());

    }

    public void Lose()
    {
        m_IsSusceptible = false;

        // Enemy Attack
        EnemyManager.Instance.EnemyAttack();

        m_Life--;

        UIManager.Instance.UpdateHearts(m_Life);

        if (m_Life <= 0)
        {
            m_GameLost = true;

            // Kill Player
            m_Wizard.Death();

            // Show max level and current level
            m_MaxFloor = (m_MaxFloor > m_CurrentFloor) ? m_MaxFloor : m_CurrentFloor;
            UIManager.Instance.SetFloorRecords(m_CurrentFloor, m_MaxFloor);


            // Go to title screen
            StartCoroutine(WizardDeathSequence_cr());
        }

    }

    public bool GetGameLost()
    {
        return m_GameLost;
    }

    public void Shield()
    {
        EnemyManager.Instance.EnemyAttack();
    }


    public void Reset()
    {
        m_GameLost = false;

        // Reset Life
        m_Life = 3;
        UIManager.Instance.UpdateHearts(m_Life);

        // Reset Floor        
        m_CurrentFloor = 0;
        UIManager.Instance.UpdateFloor(m_CurrentFloor);

        // Reset Wizard
        m_Wizard.Reset();

        // Enemy Reset
        EnemyManager.Instance.Death();
                
    }

    public void WizardSquish()
    {
        StartCoroutine(WizardSquishSequence_cr());
    }

    private IEnumerator WizardSquishSequence_cr()
    {
        float t = 0;
        Vector2 fullSize = m_Wizard.transform.localScale;
        Vector2 tinySize = new Vector2(m_Wizard.transform.localScale.x, 0);
        while (t < 2)
        {
            m_Wizard.transform.localScale = Vector3.Lerp(fullSize, tinySize, t / 2);
            t += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.25f);

        m_Wizard.transform.localScale = fullSize;
    }

    private IEnumerator MonsterDeathSequence_cr()
    {
        EnemyManager.Instance.PreDeath();

        UIManager.Instance.ActivateSpellWheel(false);
        // move to player
        float t = 0;
        Vector2 start = m_ArrivalPos.position;
        while (t < 4)
        {
            m_Wizard.transform.position = Vector3.Lerp(start, m_ExitPos.position, t / 4);
            t += Time.deltaTime;
            yield return null;
        }

        EnemyManager.Instance.Death();
        m_Wizard.transform.position = m_ExitPos.position;

        yield return new WaitForSeconds(0.05f);

        m_Wizard.GetComponentInChildren<SpriteRenderer>().flipX = true;

        yield return new WaitForSeconds(0.5f);

        //Change Floor
        m_CurrentFloor++;
        UIManager.Instance.UpdateFloor(m_CurrentFloor);

        // Move Player
        m_Wizard.GetComponentInChildren<SpriteRenderer>().flipX = false;
        m_Wizard.transform.position = m_ArrivalPos.position;

        //Spawn new enemy
        EnemyManager.Instance.NewEnemy();

        UIManager.Instance.ActivateSpellWheel(true);
    }

    private IEnumerator WizardDeathSequence_cr()
    {
        float t = 0;
        while (t < 3.5)
        {
            t += Time.deltaTime;
            yield return null;
        }

        UIManager.Instance.ReturnMenu();

        Reset();
    }
}
