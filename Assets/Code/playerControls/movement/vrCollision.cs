using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrCollision : MonoBehaviour
{
    public Transform head;
    public Transform heightAdjuster;

    // Start is called before the first frame update
    void Start()
    {
        heightAdjuster = transform.parent.parent.Find("heightAdj");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(head.position.x, transform.position.y, head.position.z);
        heightAdjuster.position = new Vector3(head.position.x, heightAdjuster.position.y, head.position.z);
    }
}
