using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveControler : MonoBehaviour
{
    Circle Player;
    Vector3 Target;
    [SerializeField] float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Player = Circle.Instant;
    }

    // Update is called once per frame
    void Update()
    {
        Target = Player.transform.position;
        Target.z=-10;

        this.transform.position = Vector3.MoveTowards(this.transform.position, Target, Speed * Time.deltaTime);
        //this.transform.position = Target;
    }
}
