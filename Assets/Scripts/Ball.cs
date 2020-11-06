using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public BallColor ballColor;

    public Rigidbody rgd;

    public BoardHolder currentHolder;

    public bool HasPlace 
    {
        get 
        {
            return currentHolder.holderColor == ballColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BoardHolder>() != null)
        {
            currentHolder = other.gameObject.GetComponent<BoardHolder>();
        }
    }

    public void JumpToCenter(Vector3 jumpCenter) 
    {
        rgd.isKinematic = true;

        transform.DOJump(jumpCenter + new Vector3(Random.Range(-.05f, .05f), 0, 0), .2f, 1,Random.Range(.3f,1.2f)).OnComplete(() =>
        {
             rgd.isKinematic = false;
        });
    }
}

public enum BallColor 
{
    BLUE,
    RED
}
