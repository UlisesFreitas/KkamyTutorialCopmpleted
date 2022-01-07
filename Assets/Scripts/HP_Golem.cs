using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HP_Golem : MonoBehaviour
{
    public float hp;
    public float hp_Cur;

    public Image hpBar_Front;
    public Image hpBar_Back;

    // Start is called before the first frame update
    void Start()
    {
        hp_Cur = hp;    
    }

    void SyncBar()
    {
        hpBar_Front.fillAmount = hp_Cur / hp;
        if(hpBar_Back.fillAmount > hpBar_Front.fillAmount)
        {
            hpBar_Back.fillAmount = Mathf.Lerp(hpBar_Back.fillAmount,hpBar_Front.fillAmount, Time.deltaTime);
        }

    }
    // Update is called once per frame
    void Update()
    {
        SyncBar();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Col_PlayerAtk")
        {
            hp_Cur -= Random.Range(100,500);
        }
    }
}
