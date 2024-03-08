using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    // Controls the current health of the object    
    public float CurrentHealth { get; set; }

    private void Awake()
    {
        CurrentHealth = initialHealth;
    }

    // Take the amount of damage we pass in parameters
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }

    // Take the amount of damage we pass in parameters
    public void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0)
        {
            return;
        }

        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // Kills the game object
    private void Die()
    {
        /*if (character != null)
        {
            collider2D.enabled = false;
            spriteRenderer.enabled = false;
        }*/

        if (destroyObject)
        {
            DestroyObject();
        }
    }

    // Revive this game object    
    public void Revive()
    {
        /*if (character != null)
        {
            collider2D.enabled = true;
            spriteRenderer.enabled = true;
        }

        gameObject.SetActive(true);*/

    }

    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

}

