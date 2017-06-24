using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

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

    public void OnSpellClick(Image aImage)
    {
        SpellManager.Instance.SpellClick(aImage.sprite);
    }

    public void AssignNewSpell(int i)
    {
        SpellManager.Instance.AssignSpell(i);
    }

}
