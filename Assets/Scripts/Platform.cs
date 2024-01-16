using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waitedTime;

    public float startwaitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) {
            waitedTime = startwaitTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            if (waitedTime <= 0) {
                effector.rotationalOffset = 180.0f;
                waitedTime = startwaitTime;
            }
            else {
                waitedTime -= Time.deltaTime;
            }
        }
        if(Input.GetKey("space")){
            effector.rotationalOffset = 0f;
        }
    }
}
