using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOnLine : MonoBehaviour
{
    Vector3 endPos;
    float step = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (step != -1){

            if (Vector3.Distance(transform.position, endPos) < step * 2){
                Debug.Log("Destroying");
                Destroy(this);
            }

            transform.position = Vector3.MoveTowards(transform.position, endPos, step);
        }        
    }

    public void defineEndPos(Vector3 endPos, float step){

        this.endPos = endPos;
        this.step = step;
    }
}
