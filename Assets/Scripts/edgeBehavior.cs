using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeBehavior : MonoBehaviour {

    public GameObject collisionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (!gameManager.Instance.gameIsOver)
            {
                if (collisionPrefab)
                {
                    Instantiate(collisionPrefab, transform.position, transform.rotation);
                }

                gameManager.Instance.score -= 10;
            }
        }
    }
}
