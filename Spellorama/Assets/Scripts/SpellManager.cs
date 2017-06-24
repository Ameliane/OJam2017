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

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < m_Spells.Length; i++)
        {
            AssignSpell(i);
        }
    }

    void Update()
    {

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
    }

}
