using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Singleton<Circle>{   
    public float JumpForce;
    Rigidbody2D rigi;
    [SerializeField] float Speed;
    Vector2 movement = Vector2.zero;
    [SerializeField] bool IsGround = false;
    [SerializeField] bool IsLadder = false;
    Collider2D Colli;
    [SerializeField] public AnimControl AnimController;
    private bool _IsController = true;
    void Start()
    {
        rigi=this.GetComponent<Rigidbody2D>();//luu dem
        Colli = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Target = Player.transform.position;
        Target.z=-10;
        Camera.main.transform.position =Target;*/
        /// tao camera theo player

        /*if(IsGround && IsLadder && Input.GetAxisRaw("Vertical") !=0){
            this.Colli.isTrigger = true;
        }
        else
            {
                 this.Colli.isTrigger = false;
            }*/
            // treo len troe xuong thang  
        Moving();
        ChangeAnim();
    }

    

    void ChangeAnim(){
        if(AnimController.playerState == AnimControl.STATE.HURT)
        return;
        if(rigi.gravityScale == 0){
            AnimController.playerState = AnimControl.STATE.CLIMB;
        }

        if(IsGround){
          if(Input.GetKey(KeyCode.Z)){
              AnimController.playerState = AnimControl.STATE.SHOOT;

        }
            else if(Input.GetAxisRaw("Horizontal") ==0){
            AnimController.playerState = AnimControl.STATE.IDLE;
        }
        else{
            AnimController.playerState = AnimControl.STATE.RUN;
            }
        }
        else{
            AnimController.playerState = AnimControl.STATE.JUMP;
        }

}
    void Moving(){//phai goi ham Moving ra thi obj moi di chuyen
       IsGround = GroundCheck();
       if(! _IsController)
       return;

       Vector2 SCALE = this.transform.localScale;

       if(movement.x>0){
           SCALE.x = Mathf.Abs(SCALE.x);
       }
       else if(movement.x<0){
           SCALE.x = -Mathf.Abs(SCALE.x);
       }
       this.transform.localScale = SCALE;
       

       if(rigi.gravityScale ==1){
           movement.y=rigi.velocity.y;
       }
       else{
           movement.y= Input.GetAxisRaw("Vertical") * Speed *Time.deltaTime;
       }
       //movement.y=rigi.velocity.y;

       if(Input.GetKeyDown(KeyCode.Mouse0)){
           if(IsGround){

           
           rigi.AddForce( new Vector2(0, JumpForce));
           IsGround=false;
           }
       }
         movement.x =Input.GetAxisRaw("Horizontal") *Speed*Time.deltaTime;
         rigi.velocity = movement;
    }
    bool GroundCheck(){
        float lenRay= 0.5f;
        RaycastHit2D[] hits= new RaycastHit2D[10];
         Colli.Cast(Vector2.down * lenRay, hits);//down=vector2(0,-1)

         foreach(RaycastHit2D h in hits){
             if(h.collider !=null){

                 return true;
             }
         }
         return false;
         
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Ladder"){
            IsLadder =true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag=="Ladder"){
            IsLadder=false;
        }
    }
    public void SetIsController(bool IsControl, float TimeControlback){
        this._IsController = IsControl;
        if(IsControl)
        return;
        StartCoroutine(Controlback(TimeControlback));
    }

    //luong
    IEnumerable Controlback(float timeDelay){
        yield return new WaitForSeconds(timeDelay);
        _IsController =true;
    }
    public void GetDmg(){
        AnimController.playerState = AnimControl.STATE.HURT;
        StartCoroutine(HurtExit(1));
    }
    IEnumerable HurtExit(float timeDelay){
        yield return new WaitForSeconds(timeDelay);
        AnimController.playerState = AnimControl.STATE.IDLE;
    }
}
