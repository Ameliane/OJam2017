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

    public void Win()
    {
        //Move Player
        StartCoroutine(MonsterDeathSequence_cr());

    }

    public void Lose()
    {
        // Enemy Attack
        EnemyManager.Instance.EnemyAttack();

        m_Life--;

        UIManager.Instance.UpdateHearts(m_Life);

        if (m_Life <= 0)
        {            
            // Kill Player
            m_Wizard.Death();

            // Show max level and current level
            m_MaxFloor = (m_MaxFloor > m_CurrentFloor) ? m_MaxFloor : m_CurrentFloor;
            UIManager.Instance.SetFloorRecords(m_CurrentFloor, m_MaxFloor);


            // Go to title screen
            StartCoroutine(WizardDeathSequence_cr());
        }

    }

    public void Shield()
    {
        EnemyManager.Instance.EnemyAttack();
    }

    public void Reset()
    {
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

        yield return null;

        m_Wizard.GetComponentInChildren<SpriteRenderer>().flipX = true;

        t = 0;
        while (t < 0.5)
        {
            t += Time.deltaTime;
            yield return null;
        }

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
        while (t < 5)
        {
            t += Time.deltaTime;
            yield return null;
        }

        UIManager.Instance.ReturnMenu();

        Reset();
    }
}
