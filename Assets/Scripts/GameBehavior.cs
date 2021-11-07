using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Text goals_collected_text;
    public Text goals_remaining_text;
    public GameObject end_panel;
    public GameObject game_entities;

    GameObject live_game_entities;
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
        game_entities.SetActive(false);
        live_game_entities = Instantiate(game_entities, GameObject.Find("Environment").transform);
        live_game_entities.SetActive(true);
    }

    public void MarbleLose() {
        Time.timeScale = 0;
        end_panel.GetComponent<EndBehavior>().SetMessage("You Lose!");
    }

    public void RestartGame() {
        Destroy(live_game_entities);
        live_game_entities = Instantiate(game_entities, GameObject.Find("Environment").transform);
        live_game_entities.SetActive(true);
        end_panel.GetComponent<EndBehavior>().Hide();
        Time.timeScale = 1;
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
