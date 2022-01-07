using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HitBox_Player : MonoBehaviour
{

    public Animator playerAni;
    public TextMeshProUGUI message;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Col_EnemyAtk")
        {
            if(gameObject.tag == "HitBox_Player")
            {
                playerAni.Play("Knight_Rigidity");
                message.text = "Rigidity";
                message.gameObject.SetActive(true);
            }

            if(gameObject.tag == "Defense")
            {
                message.text = "Block";
                message.gameObject.SetActive(true);
            }

            if(gameObject.tag == "Parrying")
            {
                playerAni.Play("Knight_Counter");
                message.text = "Parrying";
                message.gameObject.SetActive(true);
            }

        }
    }
}
