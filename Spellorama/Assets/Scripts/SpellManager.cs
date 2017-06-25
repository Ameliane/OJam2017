using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellManager : MonoBehaviour
{
    public static SpellManager Instance = null;

    [SerializeField]
    Spell[] m_Spells;

    [SerializeField]
    SpellDictionary m_SpellDictionary;

    public float m_EffecTime = 2f;

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

    public void ResetAllSpells()
    {
        for (int i = 0; i < m_Spells.Length; i++)
        {
            AssignSpell(i);
        }
    }

    public void AssignSpell(int i)
    {
        int random = Random.Range(0, (int)Spell.SpellType.Count);
        m_Spells[i].m_Type = (Spell.SpellType)random;
        m_Spells[i].m_Image.sprite = m_SpellDictionary.GetSprite(m_Spells[i].m_Type);
    }

    public void SpellClick(Sprite aSprite)
    {
        m_SpellDictionary.GetScript(aSprite).enabled = true;
        UIManager.Instance.ActivateSpellWheel(false);
    }

    public void StartEffect(Spell.SpellType aType)
    {
        m_SpellDictionary.StartEffect(aType);
    }

}
