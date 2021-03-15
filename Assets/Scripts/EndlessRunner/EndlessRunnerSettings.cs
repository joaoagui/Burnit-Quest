using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessRunnerSettings : MonoBehaviour
{
    private string Stage;

    public TextMeshPro GoalText;

    //spawn system
    static public bool enemies = true;
    static public bool coins = true;
    static public bool crates = true;
    
    //goal system
    static public bool timerGoal = false;
    static public bool caloriesGoal = false;
    static public float targetTime = 5;
    static public float targetCalories = 10;

    // Update is called once per frame
    void Update()
    {
        if(timerGoal == true)
        {
            GoalText.text = "" + targetTime + "min";
        }     
        else if(caloriesGoal == true)
        {
            GoalText.text = "" + targetCalories + "cal";
        }
        else if (caloriesGoal == false && timerGoal == false)
        {
            GoalText.text = "-";
        }

       
    }

    public void ToggleEnemies()
    {
        enemies = !enemies;
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void ToggleCrates()
    {
        crates = !crates;
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void ToggleCoins()
    {
        coins = !coins;
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void IncreaseTime()
    {
        if(targetTime <= 55)
        {
            targetTime += 5;
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }
    public void DecreaseTime()
    {
        if (targetTime >= 10)
        {
            targetTime -= 5;
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }

    public void IncreaseCalories()
    {
        if (targetCalories <= 1000)
        {
            targetCalories += 10;
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }
    public void DecreaseCalories()
    {
        if (targetCalories >= 20)
        {
            targetCalories -= 10;
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }

    public void GoalDropdown(int val)
    {
        if (val == 0)
        {
            timerGoal = false;
            targetTime = 0;
            caloriesGoal = false;
            targetCalories = 0;
            FindObjectOfType<AudioManager>().Play("Select");

        }
        if (val == 1)
        {
            caloriesGoal = true;
            timerGoal = false;
            targetTime = 0;
            targetCalories = 10;
            FindObjectOfType<AudioManager>().Play("Select");
        }
        if (val == 2)
        {
            timerGoal = true;
            caloriesGoal = false;
            targetCalories = 0;
            targetTime = 5;
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }


}
