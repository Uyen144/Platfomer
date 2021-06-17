using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_base : MonoBehaviour
{
     [Header("Base Infor")]// tieu de
    [SerializeField] protected float HP=100;
    [SerializeField] protected float Dmg=50; 
    [SerializeField] protected float RangeDetect = 1;
    [SerializeField] GameObject Target = null;
    [SerializeField] protected LineRenderer Line = null;
    // Start is called before the first frame update
    void Start()
    {
        Line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void Attack(){
        if(Target == null)
        return;
    }
    protected void DetectTarget(){
        if(Vector2.Distance(Circle.Instant.transform.position, this.transform.position) > RangeDetect){
            Target = null;
        }
        else{
            Target = Circle.Instant.gameObject;
        }
        if(Target ==null){
            Line.enabled  = false;
            return;
        }
        Line.SetPosition(0, this.transform.position);
        Line.SetPosition(1, Target.transform.position);
        Line.enabled = true;
        Debug.DrawLine(this.transform.position, Target.transform.position, Color.yellow);
    }
   protected void OnTriggerEnter2D(Collider2D collision){
       if(collision.tag.Equals("Player")){
           ColliPlayer(collision.gameObject);
       }
    }
    protected virtual void ColliPlayer(GameObject Player){

    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, RangeDetect);
    }
}
