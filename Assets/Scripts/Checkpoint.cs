using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform spawnPoint;

    private Animator anim;
    public ParticleSystem checkpointEffect;
    private bool isOn;

    public int sFX;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isOn)
        {
            anim.Play("Checkpoint On");
        }
        else
        {
            anim.Play("Checkpoint Off");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SetSpawnPoint(spawnPoint.position);

            for (int i = 0; i < CheckpointManager.instance.checkpoints.Length; i++)
            {
                CheckpointManager.instance.checkpoints[i].CheckpointOff();
                var mainm = checkpointEffect.main;
                mainm.loop = false;
            }
            
            CheckpointOn();
        }
    }

    private void CheckpointOn()
    {
        var main = checkpointEffect.main;
        main.loop = true;
        checkpointEffect.Play();
        isOn = true;
    }

    private void CheckpointOff()
    {
        var mainm = checkpointEffect.main;
        mainm.loop = false;
        isOn = false;
    }

    public void PlaySound()
    {
        AudioManager.instance.PlaySFX(sFX);
    }
}
