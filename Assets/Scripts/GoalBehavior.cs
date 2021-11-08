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
        if (game_manager != null)
            game_manager.GetComponent<GameBehavior>().AddGoal();
    }
}
