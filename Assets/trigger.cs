using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            virtualCamera.transform.gameObject.SetActive(true);
        }
    }
}
