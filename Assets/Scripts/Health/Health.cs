using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Action<int> OnHealthChanged;

    [Header("Health")]
    [SerializeField] private int initialHealth = 8;
    [SerializeField] private int maxHealth = 8;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    // Controls the current health of the object    
    public int CurrentHealth { get; set; }

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddLife(1);
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

        UpdateLifesUI();
    }

    public void AddLife(int Heal)
    {
        if (CurrentHealth >= maxHealth)
        {
            return;
        }

        CurrentHealth += Heal;

        UpdateLifesUI();
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

        Debug.Log("Die");
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

        Debug.Log("Revive");
    }

    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    private void UpdateLifesUI()
    {
        OnHealthChanged?.Invoke(CurrentHealth);
    }


}

