using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Dmg;
    Vector2 SCALE;
    private float _Way=1;
    public float Way{
        get{return _Way;}
        set{
            if(value>0){
                _Way=1;
            }
            else{
                _Way=-1;
            }
        }
    }
    Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        SCALE = this.transform.localScale;
        rigi=this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = new Vector2(Speed * _Way * Time.deltaTime, 0);
        this.transform.localScale = new Vector2(SCALE.x * _Way, SCALE.y);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(this.gameObject);
    }
}
