using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public float HP = 100f;
    public Image LineBar;

    public void ConditionalDamage()
    {
        HP += 5;
        LineBar.fillAmount = HP / 100;
    }
}
