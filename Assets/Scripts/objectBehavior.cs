using UnityEngine;

public class objectBehavior : MonoBehaviour {

    TimedObjectDestructor tod ;

    public float scoreAmount = 0f;

    public void Start()
    {
        tod = GameObject.FindObjectOfType<TimedObjectDestructor>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        {
            if (collision.gameObject.tag == "Player")
            {
                tod.DestroyNow(scoreAmount);
            }
        }
    }
}
