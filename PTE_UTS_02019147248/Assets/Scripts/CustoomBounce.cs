using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustoomBounce : MonoBehaviour
{
    BoxCollider2D bc2d;

    private void Awake()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //Find the relative point. (Ball.x - Paddle.x)/Paddle.width
            float relativePosition = GetRelativePosition(other.transform);
            //Change the velocity of the ball depending on the relative point.
            other.rigidbody.velocity = new Vector2(relativePosition,1).normalized * other.rigidbody.velocity.magnitude;
        }
    }

    public float GetRelativePosition(Transform other)
    {
        //Find the relative ponint. (Ball.x - Paddle.x)/Paddle.widht
        return (other.position.x - transform.position.x) / bc2d.bounds.size.x;
    }
   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
