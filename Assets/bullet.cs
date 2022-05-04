using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Range(0, 20)] public float speed;
    [Range(0, 20)] public float xRotateSpeed;
    [Range(0, 20)] public float yRotateSpeed;
    [Range(-10, 20)] public float zRotateSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(xRotateSpeed, yRotateSpeed, zRotateSpeed));

        transform.Translate(new Vector3(0,2,0) * speed * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tutorialBossWall"))
        {
            Destroy(gameObject);
        }
    }
}
