using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float life = 10;
    public float maxLife = 10;

    public float damageAnimationTime = 1;
    private float lastDamage = 0;
    public GameObject damageTexture;
    public GameObject deathText;

    private bool damaged = false;
    private GameObject lifehud;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        lifehud = GameObject.FindGameObjectWithTag("life hud");
        animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageTexture.SetActive(true);
            lastDamage += Time.deltaTime;
            if(lastDamage >= damageAnimationTime)
            {
                damageTexture.SetActive(false);
                lastDamage = 0;
                damaged = false;
            }
        }          

    }

    public void Damage(float value)
    {
        life -= value;
        damaged = true;

        float ratio = life / maxLife;

        for (int i = 0; i < lifehud.transform.childCount; i++)
        {
            if (i < ratio * lifehud.transform.childCount)
            {
                lifehud.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                lifehud.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        if (life <= 0)
        {
            gameObject.GetComponent<MoveBehaviour>().SetCanMove(false);
            deathText.SetActive(true);
            animator.SetTrigger("death");
        }

    }
}
