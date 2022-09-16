using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float maxHealt;

    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    private float currentHealt;

    private GameManager GM;

    private void Start()
    {
        currentHealt = maxHealt;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void DecreaseHealt(float amount)
    {
        currentHealt -= amount;
        if (currentHealt <= 0.0f)
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


