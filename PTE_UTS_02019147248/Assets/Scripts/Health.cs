using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] int scoreValue = 1;

    
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            health--;
            if (health<=0)
            {
                GameObject.FindObjectOfType<GameSession>().IncreaseScore(scoreValue);
                Destroy(gameObject);
            }
            }
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
