using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RandomMove : MonoBehaviour
{
    private Vector3 goal;
    private Vector3 movement;
    [SerializeField] private float speed;
    [SerializeField] private float rangeX1=-4f;
    [SerializeField] private float rangex2=-54f;
    [SerializeField] private float rangez1=-3f;
    [SerializeField] private float rangez2=-60f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, speed * Time.deltaTime);
        if (transform.position == goal)
        {
            goal = ChooseNewGoal();
        }
    }

    private Vector3 ChooseNewGoal()
    {
        movement = new Vector3(Random.Range(rangeX1, rangex2), 0,Random.Range(rangez1, rangez2));
        return movement;
    }

}

