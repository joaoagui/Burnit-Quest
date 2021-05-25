using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Regata : MonoBehaviour
{
    public GameObject hamShot;
    public GameObject Special;

    private float stepGoal;
    private float punchGoal;
    private float situpGoal;
    private float squatGoal;
    private float JumpingJackGoal;


    public GameObject SpeechBubble;

    public GameObject SpeechBubbleThinking;
    public GameObject SpeechBubbleHappy;
    public GameObject SpeechBubbleSassy;
    public GameObject SpeechBubbleSad;

    public TextMeshPro QuoteText;

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

    public Transform firepoint;

    private float randomizer;

    private IEnumerator coroutine;

    private AudioSource audioSource;


    private void Start()
    {
        punchGoal = 3;
        JumpingJackGoal = 10;
        stepGoal = 100;
        situpGoal = 8;
        squatGoal = 3;

        audioSource.GetComponent<AudioSource>();
    }

    private void Update()
    {

        if(DataManager.Instance.playerData.stepsNumber > stepGoal)
        {
            stepGoal = stepGoal + 100;
            coroutine = QuoteWalk();
            StartCoroutine(coroutine);
        }

        if (DataManager.Instance.playerData.jumpingJacks > JumpingJackGoal)
        {
            stepGoal = JumpingJackGoal + 10;
            coroutine = QuoteJJ();
            StartCoroutine(coroutine);
        }

        if (DataManager.Instance.playerData.punches > punchGoal)
        {
            stepGoal = punchGoal + 3;
            coroutine = QuotePunch();
            StartCoroutine(coroutine);
        }

        if (DataManager.Instance.playerData.sitUps > situpGoal)
        {
            stepGoal = situpGoal + 5;
            coroutine = QuoteSitUp();
            StartCoroutine(coroutine);
        }

        if (DataManager.Instance.playerData.Squats > squatGoal)
        {
            stepGoal = squatGoal + 3;
            coroutine = QuoteSquat();
            StartCoroutine(coroutine);
        }
    }

    public void FireShot()
    {
        Instantiate(hamShot, firepoint.position, Quaternion.identity);
    }

    public void ShootSpecial()
    {
        Instantiate(hamShot, firepoint.position, Quaternion.identity);
    }

    void ClearBubbles()
    {
        SpeechBubble.SetActive(false);
        SpeechBubbleHappy.SetActive(false);
        SpeechBubbleSassy.SetActive(false);
        SpeechBubbleThinking.SetActive(false);
        SpeechBubbleSad.SetActive(false);
    }

    public IEnumerator QuoteWalk()
    {
        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleHappy.SetActive(true);

        if (randomizer > 1)
        {
            QuoteText.text = "" + WalkQuote1;
            audioSource.PlayOneShot(WalkClip1);
        }

        if (randomizer >=1 && randomizer < 2)
        {
            QuoteText.text = "" + WalkQuote2;
            audioSource.PlayOneShot(WalkClip2);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + WalkQuote3;
            audioSource.PlayOneShot(WalkClip3);

        }

        yield return new WaitForSeconds(3f);
        ClearBubbles();

    }

    public IEnumerator QuotePunch()
    {
        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleSassy.SetActive(true);

        if (randomizer > 1)
        {
            QuoteText.text = "" + PunchQuote1;
            audioSource.PlayOneShot(PunchClip1);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + PunchQuote2;
            audioSource.PlayOneShot(PunchClip2);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + PunchQuote3;
            audioSource.PlayOneShot(PunchClip3);

        }

        yield return new WaitForSeconds(3f);
        ClearBubbles();
    }

    public IEnumerator QuoteSquat()
    {
        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleHappy.SetActive(true);

        if (randomizer > 1)
        {
            QuoteText.text = "" + SquatQuote1;
            audioSource.PlayOneShot(SquatClip1);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + SquatQuote2;
            audioSource.PlayOneShot(SquatClip2);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + SquatQuote3;
            audioSource.PlayOneShot(SquatClip3);

        }

        yield return new WaitForSeconds(3f);
        ClearBubbles();

    }

    public IEnumerator QuoteSitUp()
    {
        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleSassy.SetActive(true);

        if (randomizer > 1)
        {
            QuoteText.text = "" + SitupQuote1;
            audioSource.PlayOneShot(SitupClip1);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + SitupQuote2;
            audioSource.PlayOneShot(SitupClip2);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + SitupQuote3;
            audioSource.PlayOneShot(SitupClip3);

        }

        yield return new WaitForSeconds(3f);
        ClearBubbles();
    }


    public IEnumerator QuoteJJ()
    {
        randomizer = Random.Range(0, 3);
        SpeechBubble.SetActive(true);
        SpeechBubbleHappy.SetActive(true);

        if (randomizer > 1)
        {
            QuoteText.text = "" + JJQuote1;
            audioSource.PlayOneShot(JJClip1);

        }

        if (randomizer >= 1 && randomizer < 2)
        {
            QuoteText.text = "" + JJQuote2;
            audioSource.PlayOneShot(JJClip3);

        }

        if (randomizer >= 2)
        {
            QuoteText.text = "" + JJQuote3;
            audioSource.PlayOneShot(JJClip2);

        }

        yield return new WaitForSeconds(3f);
        ClearBubbles();

    }


}
