using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    [SerializeField]
    Animator m_Animator;
    [SerializeField]
    GameObject m_AliveWizard;
    [SerializeField]
    GameObject m_DeadWizard;

    public void Death()
    {
        m_AliveWizard.SetActive(false);
        m_DeadWizard.SetActive(true);
    }

    public void Reset()
    {
        m_DeadWizard.SetActive(false);
        m_AliveWizard.SetActive(true);
    }
}
