using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour {

    objectBehavior ob;

    float scoreReduction = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.Instance.endGame(); 
        }

        if(collision.gameObject.tag == "Objects")
        {
            if(!gameManager.Instance.gameIsOver)
                gameManager.Instance.score -= scoreReduction;
        }
    }

}
