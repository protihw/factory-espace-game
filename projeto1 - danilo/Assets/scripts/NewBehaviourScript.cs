using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D myBody;
    public float speed;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        myBody.velocity = new Vector2(direction * speed, myBody.velocity.y);
    }
}
