using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCircle : MonoBehaviour
{
    public GameObject beforePoint;
    public GameObject afterPoint;

    Transform beforePos;
    Transform afterPos;

    float initSlope;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        beforePos = beforePoint.transform;
        afterPos = afterPoint.transform;

        float bx = beforePos.position.x;
        float by = beforePos.position.y;

        float ax = afterPos.position.x;
        float ay = afterPos.position.y;

        initSlope = (ay - by) / (ax - bx);

        distance = Mathf.Sqrt((bx - transform.position.x) * (bx - transform.position.x) +
                              (by - transform.position.y) * (by - transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        float bx = beforePos.position.x;
        float by = beforePos.position.y;

        float ax = afterPos.position.x;
        float ay = afterPos.position.y;

        float currentSlope = (ay - by) / (ax - bx);

        float angle = Mathf.Atan2(ay, ax) - Mathf.Atan2(by, bx);

        float mx = -distance * Mathf.Cos(angle);
        float my = -distance * Mathf.Sin(angle);

        transform.position = new Vector3(mx - distance, my, 0);
    }
}
