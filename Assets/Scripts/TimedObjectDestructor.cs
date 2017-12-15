using UnityEngine;

public class TimedObjectDestructor : MonoBehaviour {

    public float timeOut = 1.0f;

    public GameObject explosionPrefab;

    // Use this for initialization
    void Awake ()
    {
		// invote the DestroyNow funtion to run after timeOut seconds
		Invoke ("DestroyNow", timeOut);
	}
	

	public void DestroyNow ()
	{
        if (explosionPrefab)
        {
            // Instantiate an explosion effect at the gameObjects position and rotation
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

        // destory the game Object
        Destroy(gameObject);
	}

    public void DestroyNow(float scoreAmount)
    {
        DestroyNow();

        if(!gameManager.Instance.gameIsOver)
            gameManager.Instance.score += scoreAmount;
    }

}
