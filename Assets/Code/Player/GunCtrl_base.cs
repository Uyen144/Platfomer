using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCtrl_base : MonoBehaviour
{
    [SerializeField] GameObject Bullet_prefab;
    [SerializeField] float DelayFire=1;
    [SerializeField] float Timer =0;
    // Start is called before the first frame update
    void Start()
    {
        Timer = DelayFire;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
     protected void Shoot(){
         if(Timer>0){
             Timer -=Time.deltaTime;
         }
         if(Circle.Instant.AnimController.playerState == AnimControl.STATE.CLIMB){
             return;
         }
        if(Input.GetKey(KeyCode.Z)){
            if(Timer>0){
                return;
            }
           BulletControl B= Instantiate(Bullet_prefab, this.transform.position, Quaternion.identity).GetComponent<BulletControl>();  
           B.Way=Circle.Instant.transform.localScale.x; //quay
           Timer = DelayFire;    
         }
    }
}
