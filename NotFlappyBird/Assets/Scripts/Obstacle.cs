using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float movementSpeed;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = this.transform.position;
        this.transform.position = new Vector3(curPos.x - (movementSpeed * Time.deltaTime), curPos.y, curPos.z);
    }
}
