using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Canvas canvas;
    public Text goals_collected_text;
    public Text goals_remaining_text;
    public GameObject end_panel;

    public Button restartButtonPrefab; 

    uint goals_collected = 0;

    int RemainingGoalCount() {
        return GameObject.FindGameObjectsWithTag("Goal").Length;
    }

    void UpdateGoalsCollected() {
        if (goals_collected_text != null)
            goals_collected_text.text = "Goal: " + goals_collected.ToString();

        if (goals_remaining_text != null)
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
        CreateRestartButton();
    }

    public void AddGoal() {
        goals_collected += 1;
        UpdateGoalsCollected();
        if (RemainingGoalCount() == 0) {
            Time.timeScale = 0;
            end_panel.GetComponent<EndBehavior>().SetMessage("You Win!");
            CreateRestartButton();
        }
    }

    void CreateRestartButton()
    {
        var restartButton = GameObject.Instantiate(restartButtonPrefab, Vector3.zero, Quaternion.identity);
        var rectTransform = restartButton.GetComponent<RectTransform>();
        rectTransform.SetParent(canvas.transform);
        rectTransform.localPosition = new Vector3(0, -50, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
