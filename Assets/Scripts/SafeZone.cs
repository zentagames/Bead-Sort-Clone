using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public Transform jumpCenter;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<Ball>())
        {
            other.transform.GetComponent<Ball>().JumpToCenter(jumpCenter.transform.position);
        }
    }
}
