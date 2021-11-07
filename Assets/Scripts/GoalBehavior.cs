using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
       //Put collision code here
       Destroy (gameObject);
    }

    void OnDestroy() {
       GameObject game_manager = GameObject.Find("GameManager");
       game_manager.GetComponent<GameBehavior>().AddGoal();
    }
}
