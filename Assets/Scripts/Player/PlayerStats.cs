using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private GameUIScript GameUIScript;
    private float maxHealt=100;
    private float currentHealt;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    

    private GameManager GM;

    private void Start()
    {
        currentHealt = maxHealt;
        GameUIScript.SetMaxHealth(maxHealt);

        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void DecreaseHealt(float amount)
    {
        currentHealt -= amount;
        GameUIScript.SetHealth(currentHealt);
        if (currentHealt <= 0.1f)
        {
            Die();
        }
    }
    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        GM.Respawn();
        Destroy(gameObject);
    }
}


