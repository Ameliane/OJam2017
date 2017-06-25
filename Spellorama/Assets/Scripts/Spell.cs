using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Spell
{
    public enum SpellType
    {
        Fireball,
        Freeze,
        Rain,
        ShootingStar,
        Sleep,
        Love,
        Tornado,
        Hole,
        Frog,
        Electricity,
        Smoke,
        Chicken,
        Stink,
        Shield,
        Gravity,
        Count
    };

    public Image m_Image;
    public SpellType m_Type;

}

[System.Serializable]
public class SpellDictionary
{

    public List<Sprite> m_Sprites;
    public List<Spell.SpellType> m_Types;
    public List<MonoBehaviour> m_Scripts;
    public List<GameObject> m_Prefabs;

    public Sprite GetSprite(Spell.SpellType aType)
    {
        int index = m_Types.IndexOf(aType);
        return m_Sprites[index];
    }

    public MonoBehaviour GetScript(Sprite aSprite)
    {
        int index = m_Sprites.IndexOf(aSprite);
        return m_Scripts[index];
    }

    public void StartEffect(Spell.SpellType aType)
    {
        int index = m_Types.IndexOf(aType);

        if (m_Prefabs[index] != null)
            GameObject.Instantiate(m_Prefabs[index]);
    }
}

