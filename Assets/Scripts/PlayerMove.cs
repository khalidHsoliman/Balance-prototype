using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    [SerializeField]
    private Rigidbody playerRigid;

    private bool _moveright = false;
    private bool _moveleft = false;

    public float sideForce;


    private void Start()
    {
        if(playerRigid == null)
        {
            playerRigid = gameObject.GetComponent<Rigidbody>();
        }
    }
    void Update()
    {
        if (!gameManager.Instance.gameIsOver)
        {
            if (Input.GetKey("d"))
                _moveright = true;
            else
                _moveright = false;

            if (Input.GetKey("a"))
                _moveleft = true;
            else
                _moveleft = false;
        }
    }

    void FixedUpdate()
    {

        if (_moveright)
            playerRigid.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (_moveleft)
            playerRigid.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

    }
}
