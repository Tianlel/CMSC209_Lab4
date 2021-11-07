using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Text goals_collected_text;
    public Text goals_remaining_text;
    public GameObject foobar;
    public GameObject end_panel;

    uint goals_collected = 0;

    int RemainingGoalCount() {
        return GameObject.FindGameObjectsWithTag("Goal").Length;
    }

    void UpdateGoalsCollected() {
        goals_collected_text.text = "Goal: " + goals_collected.ToString();
        goals_remaining_text.text = "Goals Remaining: " + RemainingGoalCount().ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGoalsCollected();
    }

    public void MarbleLose() {
        Time.timeScale = 0;
        end_panel.GetComponent<EndBehavior>().SetMessage("You Lose!");
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddGoal() {
        goals_collected += 1;
        UpdateGoalsCollected();
        if (RemainingGoalCount() == 0) {
            Time.timeScale = 0;
            end_panel.GetComponent<EndBehavior>().SetMessage("You Win!");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
