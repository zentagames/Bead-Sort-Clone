using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacoomController : MonoBehaviour
{
    public static VacoomController Instance;

    public Transform magnetCenter;

    public BallColor currentColor;

    public float magnetForce = 100;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ChangeColor(BallColor color) 
    {
        currentColor = color;
    }

    public void SetPosition(Vector3 position) 
    {
        transform.position = Vector3.Lerp(transform.position,position,Time.deltaTime * 20f);
    }

    public List<Ball> innerBalls;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < innerBalls.Count; i++)
            {
                if (innerBalls[i].ballColor == currentColor)
                {
                    innerBalls[i].rgd.velocity = (magnetCenter.position - (innerBalls[i].rgd.transform.position + innerBalls[i].rgd.centerOfMass)) * magnetForce * Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            if (!innerBalls.Contains(other.gameObject.GetComponent<Ball>()))
            {
                innerBalls.Add(other.gameObject.GetComponent<Ball>());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            if (innerBalls.Contains(other.gameObject.GetComponent<Ball>()))
            {
                innerBalls.Remove(other.gameObject.GetComponent<Ball>());
            }
        }
    }
}
