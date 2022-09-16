using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDummyController : MonoBehaviour
{
    [SerializeField]
    private float maxHealt, knockbackSpeedX, knockbackSpeedY, knockbackDuration, knockbackDeathSpeedX, knockbackDeathSpeedY, deathTorque;
    [SerializeField]
    private bool applyKnockback;
    [SerializeField]
    private GameObject hitParticle;

    private float currentHealt, knockbackStart;

    private int playerFacingDirection;

    private bool playerOnLeft, knockback;

    private PlayerController pc;
    private GameObject aliveGo, brokenTopGo, brokenBotGo;
    private Rigidbody2D rbAlive, rbBrokenTop, rbBrokenBot;
    private Animator aliveAnim;
    // Start is called before the first frame update
    void Start()
    {
        currentHealt = maxHealt;
        pc = GameObject.Find("Player").GetComponent<PlayerController>();

        aliveGo = transform.Find("Alive").gameObject;
        brokenTopGo = transform.Find("Broken Top").gameObject;
        brokenBotGo = transform.Find("Broken Bottom").gameObject;

        aliveAnim = aliveGo.GetComponent<Animator>();
        rbAlive = aliveGo.GetComponent<Rigidbody2D>();
        rbBrokenTop = brokenTopGo.GetComponent<Rigidbody2D>();
        rbBrokenBot = brokenBotGo.GetComponent<Rigidbody2D>();

        aliveGo.SetActive(true);
        brokenTopGo.SetActive(false);
        brokenBotGo.SetActive(false);
    }
    void Update()
    {
        CheckKnockback();

    }
    private void Damage(float[] details)
    {
        currentHealt -= details[0];
        if (details[1] < aliveGo.transform.position.x)
        {
            playerFacingDirection = 1;
        }
        else
        {
            playerFacingDirection = -1;
        }
        Instantiate(hitParticle, aliveGo.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        if (playerFacingDirection == 1)
        {
            playerOnLeft = true;
        }
        else
        {
            playerOnLeft = false;
        }
        aliveAnim.SetBool("playerOnLeft", playerOnLeft);
        aliveAnim.SetTrigger("damage");

        if (applyKnockback && currentHealt > 0.0f)
        {
            Knockback();
        }
        if (currentHealt <= 0)
        {
            Die();
        }
    }
    private void Knockback()
    {
        knockback = true;
        knockbackStart = Time.time;
        rbAlive.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
    }

    private void CheckKnockback()
    {
        if (Time.time >= knockbackStart + knockbackDuration && knockback)
        {
            knockback = false;
            rbAlive.velocity = new Vector2(0.0f, rbAlive.velocity.y);
        }
    }
    private void Die()
    {
        aliveGo.SetActive(false);
        brokenTopGo.SetActive(true);
        brokenBotGo.SetActive(true);
        brokenTopGo.transform.position = aliveGo.transform.position;
        brokenBotGo.transform.position = aliveGo.transform.position;

        rbBrokenBot.velocity = new Vector2(knockbackSpeedX * playerFacingDirection, knockbackSpeedY);
        rbBrokenTop.velocity = new Vector2(knockbackDeathSpeedX * playerFacingDirection, knockbackDeathSpeedY);
        rbBrokenTop.AddTorque(deathTorque * -playerFacingDirection, ForceMode2D.Impulse);
    }
}
