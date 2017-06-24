using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    public Wizard m_Wizard;

    int m_CurrentFloor = 0;
    int m_MaxFloor = 0;

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

    public void Win()
    {
        //Move Player

        //Change Floor
        m_CurrentFloor++;
        UIManager.Instance.UpdateFloor(m_CurrentFloor);

        //Spawn new enemy
        EnemyManager.Instance.NewEnemy();
    }

    public void Lose()
    {
        // Kill Player
        m_Wizard.Death();

        // Show max level and current level
        m_MaxFloor = (m_MaxFloor > m_CurrentFloor) ? m_MaxFloor : m_CurrentFloor;
        UIManager.Instance.SetFloorRecords(m_CurrentFloor, m_MaxFloor);


        // TODO: Wait before doing so
        // Go to title screen
        UIManager.Instance.ReturnMenu();

        Reset();

        
        
    }

    public void Reset()
    {
        // Reset Floor        
        m_CurrentFloor = 0;
        UIManager.Instance.UpdateFloor(m_CurrentFloor);

        // Reset Wizard
        m_Wizard.Reset();

        // Enemy Reset
        EnemyManager.Instance.Death();
        //EnemyManager.Instance.NewEnemy(); // TODO: Is currently happening in UIManager, should be here.

        // Spell Reset
        SpellManager.Instance.ResetAllSpells();
    }
}
