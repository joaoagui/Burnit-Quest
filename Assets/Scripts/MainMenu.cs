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
    public TextMeshProUGUI progressText;

    [Header("Tips")]
    private float tipRandomizer;
    public TextMeshProUGUI TipText;
    public string tip1;
    public string tip2;
    public string tip3;
    public string tip4;
    public string tip5;


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
        if(operation.isDone)
        {
            SceneManager.LoadScene(levelID);
        }
    }

    private void Awake()
    {
        DataManager.Instance.LoadFromFile();
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
        //SceneManager.LoadScene("StageSelect");
        //SceneManager.GetSceneByName("StageSelect");
    }

    public void GoEndlessRunnerSettings()//startgame from the splash screen
    {
        StartCoroutine(LoadLevel("EndlessSettings"));
        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("EndlessSettings");
        //SceneManager.GetSceneByName("EndlessSettings");
    }

    public void GoEndlessRunner()//startgame from the splash screen
    {
        StartCoroutine(LoadLevel("EndlessRunner"));
        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("EndlessRunner");
        //SceneManager.GetSceneByName("EndlessRunner");

    }

    public void GoVersusSettings()//startgame from the splash screen
    {
        StartCoroutine(LoadLevel("VersusSettings"));
        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("VersusSettings");
        //SceneManager.GetSceneByName("VersusSettings");

    }

    public void GoVersusRace()//startgame from the splash screen
    {
        if(VersusSettings.GameMode == "Race")
        {
            StartCoroutine(LoadLevel("VersusRace"));
            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("VersusRace");
            //SceneManager.GetSceneByName("VersusRace");

        }
        if (VersusSettings.GameMode == "Slingshot")
        {
            StartCoroutine(LoadLevel("VersusSlingshot"));
            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("VersusSlingshot");
            //SceneManager.GetSceneByName("VersusSlingshot");

        }
        if (VersusSettings.GameMode == "Token")
        {
            StartCoroutine(LoadLevel("VersusTokenFrenzy"));
            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("VersusTokenFrenzy");
            //SceneManager.GetSceneByName("VersusTokenFrenzy");

        }
        if (VersusSettings.GameMode == "LastStanding")
        {
            StartCoroutine(LoadLevel("VersusLastStanding"));
            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("VersusLastStanding");
            //SceneManager.GetSceneByName("VersusLastStanding");

        }
    }

    public void GoSkillTree()//GoTo Skilltree
    {
        StartCoroutine(LoadLevel("SkillTree"));
        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("SkillTree");
        //SceneManager.GetSceneByName("SkillTree");

    }

    public void QuitGame()//Quit Game
    {
        Application.Quit();
    }

    public void GoSplash()//GoTo Splash page
    {
        //DataManager.Instance.LoadFromFile();
        StartCoroutine(LoadLevel("Splash"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Splash");
        //SceneManager.GetSceneByName("Splash");

    }

    public void GoCutscene1()//GoTo Stage1
    {
        StartCoroutine(LoadLevel("Cutscene_1"));
        DataManager.Instance.playerData.Cutscene1 = true;

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Cutscene_1");
        //SceneManager.GetSceneByName("Cutscene_1");

    }

    public void GoCutscene2()//GoTo Stage1
    {
        StartCoroutine(LoadLevel("Cutscene_2"));
        DataManager.Instance.playerData.Cutscene2 = true;
        FindObjectOfType<AudioManager>().Play("Select");

        //SceneManager.LoadScene("Cutscene_2");
        //SceneManager.GetSceneByName("Cutscene_2");

    }

    public void GoStage1()//GoTo Stage1
    {
        if(DataManager.Instance.playerData.Cutscene1 == false)
        {
            DataManager.Instance.playerData.Cutscene1 = true;
            StartCoroutine(LoadLevel("Cutscene_1"));
            DataManager.Instance.SaveFile();

            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("Cutscene_1");
            //SceneManager.GetSceneByName("Cutscene_1");

        }

        else if (DataManager.Instance.playerData.Cutscene1 == true)
        {
            StartCoroutine(LoadLevel("Stage1"));
            FindObjectOfType<AudioManager>().Play("Select");

            //SceneManager.LoadScene("Stage1");
            //SceneManager.GetSceneByName("Stage1");
        }
    }

    public void GoStage1_1()//GoTo Stage1
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 1;
        StartCoroutine(LoadLevel("Stage1-1"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage1-1");
        //SceneManager.GetSceneByName("Stage1-1");

    }

    public void GoStage1_2()//GoTo Stage2
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 2;
        StartCoroutine(LoadLevel("Stage1-2"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage1-2");
        //SceneManager.GetSceneByName("Stage1-2");


    }

    public void GoStage1_3()//GoTo Stage3
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 3;
        StartCoroutine(LoadLevel("Stage1-3"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage1-3");
        //SceneManager.GetSceneByName("Stage1-3");


    }

    public void GoStage1_4()//GoTo Stage4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 4;
        StartCoroutine(LoadLevel("Stage1-4"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage1-4");
       // SceneManager.GetSceneByName("Stage1-4");


    }


    public void GoStage1_5()//GoTo Stage4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 5;
        StartCoroutine(LoadLevel("Stage1-5"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage1-5");
        //SceneManager.GetSceneByName("Stage1-5");


    }

    public void GoStage2()//GoTo Stage2
    {

        if (DataManager.Instance.playerData.Cutscene2 == false && DataManager.Instance.playerData.stageComplete >= 5)
        {
            DataManager.Instance.playerData.Cutscene2 = true;
            StartCoroutine(LoadLevel("Cutscene_2"));
            DataManager.Instance.SaveFile();

            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("Cutscene_2");
            //SceneManager.GetSceneByName("Cutscene_2");

        }

        else if (DataManager.Instance.playerData.Cutscene2 == true && DataManager.Instance.playerData.stageComplete >= 5)
        {
            StartCoroutine(LoadLevel("Stage2"));
            FindObjectOfType<AudioManager>().Play("Select");

            //SceneManager.LoadScene("Stage2");
            //SceneManager.GetSceneByName("Stage2");

        }

    }

    public void GoStage2_1()//GoTo Stage1
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 6;
        StartCoroutine(LoadLevel("Stage2-1"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage2-1");
        //SceneManager.GetSceneByName("Stage2-1");

    }

    public void GoStage2_2()//GoTo Stage2
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 7;
        StartCoroutine(LoadLevel("Stage2-2"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage2-2");
        //SceneManager.GetSceneByName("Stage2-2");


    }

    public void GoStage2_3()//GoTo Stage3
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 8;
        StartCoroutine(LoadLevel("Stage2-3"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage2-3");
        //SceneManager.GetSceneByName("Stage2-3");

    }

    public void GoStage2_4()//GoTo Stage4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 9;
        StartCoroutine(LoadLevel("Stage2-4"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage2-4");
        //SceneManager.GetSceneByName("Stage2-4");


    }


    public void GoStage2_5()//GoTo Stage5
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 10;
        StartCoroutine(LoadLevel("Stage2-5"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage2-5");
        //SceneManager.GetSceneByName("Stage2-5");


    }

    public void GoStage3()//GoTo Stage1
    {

        if (DataManager.Instance.playerData.Cutscene3 == false && DataManager.Instance.playerData.stageComplete >= 10)
        {
            DataManager.Instance.playerData.Cutscene3 = true;
            StartCoroutine(LoadLevel("Cutscene_3"));
            DataManager.Instance.SaveFile();

            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("Cutscene_3");
            //SceneManager.GetSceneByName("Cutscene_3");
        }

        if (DataManager.Instance.playerData.Cutscene3 == true && DataManager.Instance.playerData.stageComplete >= 10)
        {
            StartCoroutine(LoadLevel("Stage3"));

            FindObjectOfType<AudioManager>().Play("Select");
            //SceneManager.LoadScene("Stage3");
            //SceneManager.GetSceneByName("Stage3");

        }

    }

    public void GoStage3_1()//GoTo Stage1
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 11;
        StartCoroutine(LoadLevel("Stage3-1"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage3-1");
    }

    public void GoStage3_2()//GoTo Stage2
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 12;
        StartCoroutine(LoadLevel("Stage3-2"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage3-2");
        //SceneManager.GetSceneByName("Stage3-2");

    }

    public void GoStage3_3()//GoTo Stage3
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 13;
        StartCoroutine(LoadLevel("Stage3-3"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage3-3");
        //SceneManager.GetSceneByName("Stage3-3");
    }

    public void GoStage3_4()//GoTo Stage 3- 4
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 14;
        StartCoroutine(LoadLevel("Stage3-4"));

        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage3-4");
        //SceneManager.GetSceneByName("Stage3-4");

    }


    public void GoStage3_5()//GoTo Stage 3- 5
    {
        StoreVariables();
        DataManager.Instance.playerData.currentStage = 15;
        StartCoroutine(LoadLevel("Stage3-5"));
        FindObjectOfType<AudioManager>().Play("Select");
        //SceneManager.LoadScene("Stage3-5");
        //SceneManager.GetSceneByName("Stage3-5");

    }

    public void GoStage4()//GoTo Stage selection 4
    {
        if (DataManager.Instance.playerData.stageComplete >= 15)
        {
            //StartCoroutine(LoadLevel("Stage4"));
            FindObjectOfType<AudioManager>().Play("Select");
        }


    }

    public void GoStage5()//GoTo Stage selection 5
    {
        if (DataManager.Instance.playerData.stageComplete >= 20)
        {
            //StartCoroutine(LoadLevel("Stage5"));
            FindObjectOfType<AudioManager>().Play("Select");
        }

    }

    public void GoStage6()//GoTo Stage selection 6
    {
        //SceneManager.LoadScene("Stage6");
        SceneManager.GetSceneByName("Stage6");
        FindObjectOfType<AudioManager>().Play("Select");
         
    }

    public void GoStage7()//GoTo Stage selection 7
    {
        //SceneManager.LoadScene("Stage7");
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
        DataManager.Instance.playerData.Squats = 0;
        DataManager.Instance.playerData.punches = 0;
        DataManager.Instance.playerData.stepsNumber = 0;
        DataManager.Instance.playerData.sitUps = 0;
        DataManager.Instance.playerData.jumpingJacks = 0;

        DataManager.Instance.playerData.totalCalories += DataManager.Instance.playerData.stageCalories;
        DataManager.Instance.playerData.stageCalories = 0;
        DataManager.Instance.SaveFile();
        DataManager.Instance.LoadFromFile();
    }


}
