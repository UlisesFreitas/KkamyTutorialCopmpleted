using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    Animator golemAni;
    public Transform target;
    public float golemSpeed;
    bool enableAct;
    int atkStep;


    // Start is called before the first frame update
    void Start()
    {
        golemAni = GetComponent<Animator>();
        enableAct = true;
        
    }

    void RotateGolem()
    {
        Vector3 dir = target.position - transform.position;
        transform.localRotation = 
        Quaternion.Slerp(transform.localRotation,
        Quaternion.LookRotation(dir),5* Time.deltaTime);
    }

    void MoveGolem()
    {
        if((target.position - transform.position).magnitude >= 10)
        {
            golemAni.SetBool("Walk", true);
            transform.Translate(Vector3.forward * golemSpeed * Time.deltaTime, Space.Self);   
        }

        if((target.position - transform.position).magnitude < 10)
        {
            golemAni.SetBool("Walk", false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(enableAct)
        {
            RotateGolem();
            MoveGolem();
        }
    }

    void GolemAtk()
    {
        if((target.position - transform.position).magnitude < 10)
        {
            switch (atkStep)
            {
                case 0:
                    atkStep +=1;
                    golemAni.Play("Golem_AtkA");
                break;
                case 1:
                    atkStep +=1;
                    golemAni.Play("Golem_AtkB");
                break;
                case 2:
                    atkStep =0;
                    golemAni.Play("Golem_AtkC");
                break;
            }
        }
    }

    void FreezeGolem()
    {
        enableAct = false;
    }
    void UnFreezeGolem()
    {
        enableAct=true;
    }

}
