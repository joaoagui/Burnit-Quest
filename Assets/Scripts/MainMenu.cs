using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 2f;

    public PlayerData playerData;


    public Image loadingBar;
    public TextMeshPro progressText;

    [Header("Tips")]
    private float tipRandomizer;
    public TextMeshPro TipText;
    public string tip1;
    public string tip2;
    public string tip3;
    public string tip4;
    public string tip5;


    //transition screen
    IEnumerator LoadLevel(string levelID)
    {
        PauseMenu.paused = false;
        loadingBar.fillAmount = 0f;
        progressText.text = 0 + "%";
        transition.SetTrigger("Start");

        //randomizing and setting tips
        yield return new WaitForSeconds(transitionTime);

        AsyncOperation operation = SceneManager.LoadSceneAsync(levelID);
        
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            loadingBar.fillAmount = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tipRandomizer = Random.Range(0f, 5f);
    }

    private void Update()
    {
        if (tipRandomizer > 0f && tipRandomizer <= 1f)
        {
            TipText.text = "" + tip1;
        }
        else if (tipRandomizer > 1f && tipRandomizer <= 2f)
        {
            TipText.text = "" + tip2;
        }
        else if (tipRandomizer > 2f && tipRandomizer <= 3f)
        {
            TipText.text = "" + tip3;
        }
        else if (tipRandomizer > 3f && tipRandomizer <= 4f)
        {
            TipText.text = "" + tip4;
        }
        else if (tipRandomizer > 4f && tipRandomizer <= 5f)
        {
            TipText.text = "" + tip5;
        }
    }

    public void StartGame()//startgame from the splash screen
    {
        StoreVariables();
        StartCoroutine(LoadLevel("StageSelect"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoEndlessRunnerSettings()//startgame from the splash screen
    {
        StartCoroutine(LoadLevel("EndlessSettings"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoEndlessRunner()//startgame from the splash screen
    {
        StartCoroutine(LoadLevel("EndlessRunner"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoVersusSettings()//startgame from the splash screen
    {
        StartCoroutine(LoadLevel("VersusSettings"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoVersusRace()//startgame from the splash screen
    {
        if(VersusSettings.GameMode == "Race")
        {
            StartCoroutine(LoadLevel("VersusRace"));
            FindObjectOfType<AudioManager>().Play("Select");
        }
        if (VersusSettings.GameMode == "Slingshot")
        {
            StartCoroutine(LoadLevel("VersusSlingshot"));
            FindObjectOfType<AudioManager>().Play("Select");
        }
        if (VersusSettings.GameMode == "Token")
        {
            StartCoroutine(LoadLevel("VersusTokenFrenzy"));
            FindObjectOfType<AudioManager>().Play("Select");
        }
        if (VersusSettings.GameMode == "LastStanding")
        {
            StartCoroutine(LoadLevel("VersusLastStanding"));
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }

    public void GoSkillTree()//GoTo Skilltree
    {
        StartCoroutine(LoadLevel("SkillTree"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoSplash()//GoTo Splash page
    {
        SceneManager.LoadScene("Splash");
        SceneManager.GetSceneByName("Splash");
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoCutscene1()//GoTo Stage1
    {
        StartCoroutine(LoadLevel("Cutscene_1"));
        DataManager.Instance.playerData.Cutscene1 = true;
    }

    public void GoStage1()//GoTo Stage1
    {
        if(DataManager.Instance.playerData.Cutscene1 == false)
        {
            DataManager.Instance.playerData.Cutscene1 = true;
            StartCoroutine(LoadLevel("Cutscene_1"));
            DataManager.Instance.SaveFile();
        }

        else if (DataManager.Instance.playerData.Cutscene1 == true)
        {
            StartCoroutine(LoadLevel("Stage1"));
            FindObjectOfType<AudioManager>().Play("Select");
        }
    }

    public void GoStage1_1()//GoTo Stage1
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 1;
        StartCoroutine(LoadLevel("Stage1-1"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoStage1_2()//GoTo Stage2
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 2;
        StartCoroutine(LoadLevel("Stage1-2"));
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage1_3()//GoTo Stage3
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 3;
        StartCoroutine(LoadLevel("Stage1-3"));
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage1_4()//GoTo Stage4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 4;
        StartCoroutine(LoadLevel("Stage1-4"));
        FindObjectOfType<AudioManager>().Play("Select");
         
    }


    public void GoStage1_5()//GoTo Stage4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 5;
        StartCoroutine(LoadLevel("Stage1-5"));
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage2()//GoTo Stage1
    {
        StartCoroutine(LoadLevel("Stage2"));
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage2_1()//GoTo Stage1
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 6;
        StartCoroutine(LoadLevel("Stage2-1"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoStage2_2()//GoTo Stage2
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 7;
        StartCoroutine(LoadLevel("Stage2-2"));
        FindObjectOfType<AudioManager>().Play("Select");

    }

    public void GoStage2_3()//GoTo Stage3
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 8;
        StartCoroutine(LoadLevel("Stage2-3"));
        FindObjectOfType<AudioManager>().Play("Select");

    }

    public void GoStage2_4()//GoTo Stage4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 9;
        StartCoroutine(LoadLevel("Stage2-4"));
        FindObjectOfType<AudioManager>().Play("Select");

    }


    public void GoStage2_5()//GoTo Stage4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 10;
        StartCoroutine(LoadLevel("Stage2-5"));
        FindObjectOfType<AudioManager>().Play("Select");

    }

    public void GoStage3()//GoTo Stage1
    {
        SceneManager.LoadScene("Stage3");
        SceneManager.GetSceneByName("Stage3");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage3_1()//GoTo Stage1
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 11;
        StartCoroutine(LoadLevel("Stage3-1"));
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void GoStage3_2()//GoTo Stage2
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 12;
        StartCoroutine(LoadLevel("Stage3-2"));
        FindObjectOfType<AudioManager>().Play("Select");

    }

    public void GoStage3_3()//GoTo Stage3
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 13;
        StartCoroutine(LoadLevel("Stage3-3"));
        FindObjectOfType<AudioManager>().Play("Select");

    }

    public void GoStage3_4()//GoTo Stage 3- 4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 14;
        StartCoroutine(LoadLevel("Stage3-4"));
        FindObjectOfType<AudioManager>().Play("Select");

    }


    public void GoStage3_5()//GoTo Stage 3- 5
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 15;
        StartCoroutine(LoadLevel("Stage3-5"));
        FindObjectOfType<AudioManager>().Play("Select");

    }

    public void GoStage4()//GoTo Stage selection 4
    {
        SceneManager.LoadScene("Stage4");
        SceneManager.GetSceneByName("Stage4");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage5()//GoTo Stage selection 5
    {
        SceneManager.LoadScene("Stage5");
        SceneManager.GetSceneByName("Stage5");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage6()//GoTo Stage selection 6
    {
        SceneManager.LoadScene("Stage6");
        SceneManager.GetSceneByName("Stage6");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage7()//GoTo Stage selection 7
    {
        SceneManager.LoadScene("Stage7");
        SceneManager.GetSceneByName("Stage7");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage8()//GoTo Stage selection 8
    {
        SceneManager.LoadScene("Stage8");
        SceneManager.GetSceneByName("Stage8");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage9()//GoTo Stage selection 9
    {
        SceneManager.LoadScene("Stage9");
        SceneManager.GetSceneByName("Stage9");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage10()//GoTo Stage selection 10
    {
        SceneManager.LoadScene("Stage10");
        SceneManager.GetSceneByName("Stage10");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void Restart()
    {
        PauseMenu.paused = false;
        StoreVariables();
        Health.health = DataManager.Instance.playerData.numOfHearts;
        CoinsScript.stageCoins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         
    }

    public void StoreVariables()
    {
        DataManager.Instance.playerData.totalCoins += CoinsScript.stageCoins;
        CoinsScript.stageCoins = 0;
        DataManager.Instance.playerData.totalCalories += DataManager.Instance.playerData.stageCalories;
        DataManager.Instance.playerData.stageCalories = 0;
        DataManager.Instance.SaveFile();
    }


}
