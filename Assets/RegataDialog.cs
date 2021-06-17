using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RegataDialog : MonoBehaviour
{
    private float stepGoal;
    private float punchGoal;
    private float situpGoal;
    private float squatGoal;
    private float JumpingJackGoal;

    private bool talking = false;

    public GameObject SpeechBubble;

    public GameObject SpeechBubbleThinking;
    public GameObject SpeechBubbleHappy;
    public GameObject SpeechBubbleSassy;
    public GameObject SpeechBubbleSad;

    public TextMeshProUGUI QuoteText;

    [Header("Walk Quotes")]
    public string WalkQuote1;
    public string WalkQuote2;
    public string WalkQuote3;
    public AudioClip WalkClip1;
    public AudioClip WalkClip2;
    public AudioClip WalkClip3;

    [Header("Punch Quotes")]
    public string PunchQuote1;
    public string PunchQuote2;
    public string PunchQuote3;
    public AudioClip PunchClip1;
    public AudioClip PunchClip2;
    public AudioClip PunchClip3;


    [Header("Squat Quotes")]
    public string SquatQuote1;
    public string SquatQuote2;
    public string SquatQuote3;
    public AudioClip SquatClip1;
    public AudioClip SquatClip2;
    public AudioClip SquatClip3;

    [Header("Jumping Jack Quotes")]
    public string JJQuote1;
    public string JJQuote2;
    public string JJQuote3;
    public AudioClip JJClip1;
    public AudioClip JJClip2;
    public AudioClip JJClip3;

    [Header("SitUp Quotes")]
    public string SitupQuote1;
    public string SitupQuote2;
    public string SitupQuote3;
    public AudioClip SitupClip1;
    public AudioClip SitupClip2;
    public AudioClip SitupClip3;

    private IEnumerator coroutine;

    public AudioSource audioSource;

    private float randomizer;

    //[Header("Debug")]
    //public Text PunchGoalText;
    //public Text PunchesText;
    //public Text SquatGoalText;
    //public Text SquatsText;
    //public Text StepGoalText;
    //public Text StepsText;
    // Start is called before the first frame update
    void Start()
    {
        punchGoal = 4;
        JumpingJackGoal = 10;
        stepGoal = 120;
        situpGoal = 8;
        squatGoal = 4;

        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.paused == false)
        {
            if (DataManager.Instance.playerData.stepsNumber > stepGoal && talking == false)
            {
                talking = true;
                stepGoal += 120;
                coroutine = QuoteWalk();
                StartCoroutine(coroutine);
            }

            else if (DataManager.Instance.playerData.jumpingJacks >= JumpingJackGoal && talking == false)
            {
                talking = true;
                JumpingJackGoal += 10;
                coroutine = QuoteJJ();
                StartCoroutine(coroutine);
            }

            else if (DataManager.Instance.playerData.punches >= punchGoal && talking == false)
            {
                talking = true;
                punchGoal += 5;
                coroutine = QuotePunch();
                StartCoroutine(coroutine);
            }

            else if (DataManager.Instance.playerData.sitUps >= situpGoal && talking == false)
            {
                talking = true;
                situpGoal += 5;
                coroutine = QuoteSitUp();
                StartCoroutine(coroutine);
            }

            else if (DataManager.Instance.playerData.Squats >= squatGoal && talking == false)
            {
                talking = true;
                squatGoal += 4;
                coroutine = QuoteSquat();
                StartCoroutine(coroutine);
            }
        }

    }

    void ClearBubbles()
    {
        SpeechBubble.SetActive(false);
        SpeechBubbleHappy.SetActive(false);
        SpeechBubbleSassy.SetActive(false);
        SpeechBubbleThinking.SetActive(false);
        SpeechBubbleSad.SetActive(false);

        talking = false;

    }


    public IEnumerator QuoteWalk()
    {
        ClearBubbles();

        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleHappy.SetActive(true);

        if (randomizer < 1)
        {
            QuoteText.text = "" + WalkQuote1;
            audioSource.PlayOneShot(WalkClip1, 1f);
        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + WalkQuote2;
            audioSource.PlayOneShot(WalkClip2, 1f);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + WalkQuote3;
            audioSource.PlayOneShot(WalkClip3, 1f);

        }

        yield return new WaitForSeconds(3f);
        ClearBubbles();

    }

    public IEnumerator QuotePunch()
    {
        ClearBubbles();

        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleSassy.SetActive(true);

        if (randomizer < 1)
        {
            QuoteText.text = "" + PunchQuote1;
            audioSource.PlayOneShot(PunchClip1, 1f);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + PunchQuote2;
            audioSource.PlayOneShot(PunchClip2, 1f);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + PunchQuote3;
            audioSource.PlayOneShot(PunchClip3, 1f);

        }

        yield return new WaitForSeconds(4f);
        ClearBubbles();
    }

    public IEnumerator QuoteSquat()
    {
        ClearBubbles();

        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleHappy.SetActive(true);

        if (randomizer < 1)
        {
            QuoteText.text = "" + SquatQuote1;
            audioSource.PlayOneShot(SquatClip1, 1f);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + SquatQuote2;
            audioSource.PlayOneShot(SquatClip2, 1f);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + SquatQuote3;
            audioSource.PlayOneShot(SquatClip3, 1f);

        }

        yield return new WaitForSeconds(4f);
        ClearBubbles();

    }

    public IEnumerator QuoteSitUp()
    {
        ClearBubbles();

        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleSassy.SetActive(true);

        if (randomizer < 1)
        {
            QuoteText.text = "" + SitupQuote1;
            audioSource.PlayOneShot(SitupClip1, 1f);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + SitupQuote2;
            audioSource.PlayOneShot(SitupClip2, 1f);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + SitupQuote3;
            audioSource.PlayOneShot(SitupClip3, 1f);

        }

        yield return new WaitForSeconds(4f);
        ClearBubbles();
    }


    public IEnumerator QuoteJJ()
    {
        ClearBubbles();

        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleHappy.SetActive(true);

        if (randomizer < 1)
        {
            QuoteText.text = "" + JJQuote1;
            audioSource.PlayOneShot(JJClip1, 1f);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + JJQuote2;
            audioSource.PlayOneShot(JJClip2, 1f);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + JJQuote3;
            audioSource.PlayOneShot(JJClip3, 1f);

        }

        yield return new WaitForSeconds(4f);
        ClearBubbles();


    }
}
