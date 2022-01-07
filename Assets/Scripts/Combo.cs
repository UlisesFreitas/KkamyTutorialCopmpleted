using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    Animator playerAnim;
    bool comboPossible;
    public int comboStep;
    bool inputSmash;
    public GameObject HitBox;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        
    }

    public void ComboPossible()
    {
        comboPossible = true;
    }

    public void NextAtk()
    {
        if(!inputSmash)
        {
            if(comboStep == 2)
                playerAnim.Play("Knight_NormalAtk_B");
            if(comboStep == 3)
                playerAnim.Play("Knight_NormalAtk_C");
        }
        if(inputSmash)
        {
            if(comboStep == 1)
                playerAnim.Play("Knight_SmashAtk_A");
            if(comboStep == 2)
                playerAnim.Play("Knight_SmashAtk_B");
            if(comboStep == 3)
                playerAnim.Play("Knight_SmashAtk_C");
        }
    }

    public void ResetCombo()
    {
        comboPossible = false;
        inputSmash = false;
        comboStep = 0;
    }

    void NormalAttack()
    {
        if(comboStep == 0)
        {
            playerAnim.Play("Knight_NormalAtk_A");
            comboStep = 1;
            return;
        }
        if(comboStep != 0)
        {
            if(comboPossible)
            {
                comboPossible= false;
                comboStep +=1;
            }
        }
    }

    void SmashAttack(){
        if(comboPossible)
        {
            comboPossible=false;
            inputSmash=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NormalAttack();
        }
        if(Input.GetMouseButtonDown(1))
        {
            SmashAttack();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.Play("Knight_Defense");
        }
    }

    
    void ChangeTag(string t)
    {
        HitBox.tag = t;
    }
}
