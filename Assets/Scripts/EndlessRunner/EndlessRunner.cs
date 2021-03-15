using UnityEngine;

public class EndlessRunner : MonoBehaviour
{

    [Header("start height 1 end height 1")]
    public GameObject Module1_1a;
    public GameObject Module1_1b;
    public GameObject Module1_1c;
    public GameObject Module1_1d;
    public GameObject Module1_1e;
    public GameObject Module1_1f;
    public GameObject Module1_1g;

    [Header("start height 2 end height 1")]
    public GameObject Module2_1a;
    public GameObject Module2_1b;

    [Header("start height 1 end height 2")]
    public GameObject Module1_2a;
    public GameObject Module1_2b;

    [Header("start height 2 end height 2")]
    public GameObject Module2_2a;
    public GameObject Module2_2b;
    public GameObject Module2_2c;
    public GameObject Module2_2d;
    public GameObject Module2_2e;
    public GameObject Module2_2f;
    public GameObject Module2_2g;

    [Header("Finish run assets")]
    public GameObject finishScreen;
    public GameObject playerWin;
    public GameObject pauseButton;

    public GameObject Player;

    private string CurrentModule;
    private float playerLastX = -90;

    private int currentHeight = 1;

    private float Randomizer;

    private AudioSource audioSource;
    public AudioClip goalDone;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.GetComponent<AudioSource>();
        //playerLastX = Player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (EndlessRunnerSettings.enemies == false)
        {
            GameObject EnemyDestroy = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(EnemyDestroy);
        }
        if (EndlessRunnerSettings.crates == false)
        {
            GameObject CrateDestroy = GameObject.FindGameObjectWithTag("Crate");
            Destroy(CrateDestroy);
        }
        if (EndlessRunnerSettings.coins == false)
        {
            GameObject CoinDestroy = GameObject.FindGameObjectWithTag("Coin");
            Destroy(CoinDestroy);
        }

        if (playerLastX < Player.transform.position.x - 44 && currentHeight == 1)
        {
            createHeight1();
        }

        if (playerLastX < Player.transform.position.x - 44 && currentHeight == 2)
        {
            createHeight2();
        }

        if (playerLastX < Player.transform.position.x - 44 && currentHeight == 3)
        {
            createHeight2();
        }

        if(DataManager.Instance.playerData.stageCalories >= EndlessRunnerSettings.targetCalories)
        {
            Finish();
        }
    }

    public void Finish()
    {
        audioSource.PlayOneShot(goalDone, 1f);
        finishScreen.SetActive(true);
        Destroy(pauseButton);
        Instantiate(playerWin, Player.transform.position, Quaternion.identity);
        Destroy(Player);
    }

    void createHeight1()
    {
        Randomizer = Random.Range(0, 9);
        playerLastX = Player.transform.position.x;
        if(Randomizer <= 1)
        {
            GameObject NewModule = Instantiate(Module1_1a, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 1 && Randomizer <= 2)
        {
            GameObject NewModule = Instantiate(Module1_1b, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 2 && Randomizer <= 3)
        {
            GameObject NewModule = Instantiate(Module1_1c, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 3 && Randomizer <= 4)
        {
            GameObject NewModule = Instantiate(Module1_1d, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 4 && Randomizer <= 5)
        {
            GameObject NewModule = Instantiate(Module1_1e, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 5 && Randomizer <= 6)
        {
            GameObject NewModule = Instantiate(Module1_1f, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 6 && Randomizer <= 7)
        {
            GameObject NewModule = Instantiate(Module1_1g, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 7 && Randomizer <= 8)
        {
            GameObject NewModule = Instantiate(Module1_2a, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 8 && Randomizer <= 9)
        {
            GameObject NewModule = Instantiate(Module1_2b, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }


    }

    void createHeight2()
    {
        Randomizer = Random.Range(0, 9);
        playerLastX = Player.transform.position.x;
        if (Randomizer <= 1)
        {
            GameObject NewModule = Instantiate(Module2_2a, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 1 && Randomizer <= 2)
        {
            GameObject NewModule = Instantiate(Module2_2b, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 2 && Randomizer <= 3)
        {
            GameObject NewModule = Instantiate(Module2_2c, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 3 && Randomizer <= 4)
        {
            GameObject NewModule = Instantiate(Module2_2d, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 4 && Randomizer <= 5)
        {
            GameObject NewModule = Instantiate(Module2_2e, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 5 && Randomizer <= 6)
        {
            GameObject NewModule = Instantiate(Module2_2f, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 6 && Randomizer <= 7)
        {
            GameObject NewModule = Instantiate(Module2_2g, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 7 && Randomizer <= 8)
        {
            GameObject NewModule = Instantiate(Module2_1a, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }
        if (Randomizer > 8 && Randomizer <= 9)
        {
            GameObject NewModule = Instantiate(Module2_1b, new Vector2(Player.transform.position.x + 100, 0), Quaternion.identity);
            currentHeight = NewModule.GetComponent<EndlessModule>().exitHeight;
        }

    }
}
