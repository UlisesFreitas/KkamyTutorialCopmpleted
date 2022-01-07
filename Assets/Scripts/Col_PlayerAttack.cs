using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Col_PlayerAttack : MonoBehaviour
{
    public Combo combo;
    public string type_Atk;

    int comboStep;
    public string dmg;
    public TextMeshProUGUI dmgText;

    public HitStop hitStop;

    private void OnEnable() {
        comboStep = combo.comboStep;
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "HitBox_Enemy")
        {
          
            dmg = string.Format("{0} + {1}", type_Atk,comboStep);
            dmgText.text = dmg;
            dmgText.gameObject.SetActive(true);

            hitStop.StopTime();

        }
    }


}
