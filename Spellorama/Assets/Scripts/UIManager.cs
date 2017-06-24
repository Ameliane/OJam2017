using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    public GameObject m_TitleCard;
    public GameObject m_FloorLevel;
    public GameObject m_SpellWheel;

    public Text m_LastFloorAttempt;
    public Text m_BestFloorAttempt;

    public Text m_Floor;

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

    public void StartGame()
    {
        m_TitleCard.SetActive(false);
        m_FloorLevel.SetActive(true);
        // TODO: Place somewhere else
        m_SpellWheel.SetActive(true);
        GameManager.Instance.StartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnMenu()
    {
        m_SpellWheel.SetActive(false);
        m_FloorLevel.SetActive(false);
        m_TitleCard.SetActive(true);
    }

    public void ActivateSpellWheel(bool aActivate)
    {
        m_SpellWheel.SetActive(aActivate);
    }

    public void OnSpellClick(Image aImage)
    {
        SpellManager.Instance.SpellClick(aImage.sprite);
    }

    public void AssignNewSpell(int i)
    {
        SpellManager.Instance.AssignSpell(i);
    }

    public void UpdateFloor(int aFloor)
    {
        m_Floor.text = "Floor " + aFloor.ToString();
    }

    public void SetFloorRecords(int aLastAttempt, int aBestAttempt)
    {
        m_LastFloorAttempt.text = "Last Attempt : Floor " + aLastAttempt.ToString();
        m_BestFloorAttempt.text = "Best Attempt : Floor " + aBestAttempt.ToString();
    }

}
