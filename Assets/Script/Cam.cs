using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    public GameObject target;

    void Start()
    {
        target = GameObject.FindWithTag("Player");  
    }
    private void Update()
    {

    }
    private void LateUpdate()
    {
        FollowCam();
    }
    private void FollowCam()
    {
        if (target.transform.position.x > -6.5 && 
        target.transform.position.x < 24 && 
        target.transform.position.y > -2.4)
        {
            Camera.main.transform.position =
            target.transform.position - Vector3.forward + new Vector3(0, 1, 0);

        }

    }

}
