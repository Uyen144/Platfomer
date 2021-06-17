using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_turret : Creep_base
{
    [Header("Creep Turret")]// tieu de
    [SerializeField] float Force=100;
    [SerializeField] float TimeDelayEffect=1;
    float TimerCount=0;
    [SerializeField] GameObject Bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectTarget();
        if(TimerCount>0){
            TimerCount -= Time.deltaTime;
        }
        Attack();
    }

    protected override void Attack()
    {
        base.Attack();

        GameObject g = Instantiate(Bullet, this.transform.position, Quaternion.identity);
    }
    protected override void ColliPlayer(GameObject Player)
    {
        if(TimerCount>0){
            return;
        }

     
        base.ColliPlayer(Player);
        Circle PlayerCtrl = Circle.Instant;
        PlayerCtrl.SetIsControlle(false, TimeDelayEffect);
        PlayerCtrl.GetDmg();
        Vector2  dir= Player.transform.position -  this.transform.position;
        float way = PlayerCtrl.transform.position.x < this.transform.position.x? 1: -1;
        dir.x *=Mathf.Abs(dir.x) *  way * Force;
        dir.y = Force;
        Player.GetComponent<Rigidbody2D>().AddForce(dir);
         TimerCount = TimeDelayEffect;
        
    }

//luong moi  IEnumerable
}
