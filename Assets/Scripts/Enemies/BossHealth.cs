using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public GameObject damageParticles;

    public static float health;
    public static float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2;

    public Image frontHealthBar;
    public Image backHealthBar;

    private Material defaultMaterial;
    public Material dmgMaterial;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = frontHealthBar.GetComponent<Material>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillB > hFraction)
        {
            coroutine = Flash();
            StartCoroutine(coroutine);
            frontHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;

            float percentComplete = lerpTimer / chipSpeed;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
    }


    public static void TakeDamage ()
    {
        health -= Bullet.dmgTotal;
        lerpTimer = 0f;
    }

    public static void TakeSuperDamage()
    {
        health -= bulletSuper.superDmgTotal;
        lerpTimer = 0f;
    }



    public IEnumerator Flash()
    {
        frontHealthBar.material = dmgMaterial;
        yield return new WaitForSeconds(0.1f);
        frontHealthBar.material = defaultMaterial;
    }

}
