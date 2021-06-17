using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer1 : AnimControl
{
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim =this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<(int)AnimControl.STATE.len; i++){
            AnimControl.STATE stateEnum = (AnimControl.STATE)i;
            if (playerState == stateEnum ){//ep kieu ve so nguyen

            Anim.SetBool(stateEnum.ToString(), true);

            }
            else{
                Anim.SetBool(stateEnum.ToString(), false);
            }
        }

        
            Anim.SetFloat("SHOOT STATE", Input.GetAxisRaw("Horizontal") !=0? 1:0);
        
        if(playerState == STATE.CLIMB){
            if(Input.GetAxisRaw("Vertical") !=0 || Input.GetAxisRaw("Horizontal") !=0){
                Anim.speed =1;
            }
            else {
                Anim.speed =0;
            }
        }
    }
}
