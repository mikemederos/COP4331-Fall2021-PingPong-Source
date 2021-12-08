using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 1.25f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }
        //rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY) {
                pos.y = boundY;
            }
            else if (pos.y < -boundY) {
                pos.y = -boundY;
            }
            
        transform.position = pos;

        foreach (Touch touch in Input.touches)
        {

            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 myposition = rb2d.position;

            if (Mathf.Abs(touchPosition.x - myposition.x) <= 2)
            {
                myposition.y = Mathf.Lerp(myposition.y, touchPosition.y, speed);
                myposition.y = Mathf.Clamp(myposition.y, -boundY, boundY);
                rb2d.position = myposition;
            }
        }
    }
}
