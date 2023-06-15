using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region Fields
    public int Healthpoints;
    public bool isAnimation;
    #endregion


    #region Methods
    // Called when attacking the player
    public virtual void Attack()
    {
        // true meaning the animation is running
        // Make sure to RESET it to false after animation
        isAnimation = true;


    }

    // Called when enemy is defending itself 
    public virtual void Defend()
    {
        // true meaning the animation is running
        // Make sure to RESET it to false after animation
        isAnimation = true;

    }

    // Called when enemy is charging
    public virtual void Charge()
    {
        // true meaning the animation is running
        // Make sure to RESET it to false after animation
        isAnimation = true;

    }

    // Method to call the animation showing the enemy entering
    public virtual void EnterAnimation()
    {

    }


    // Method to call the animation showing the enemy leave the fight
    public virtual void ChargeAnimation()
    {

    }

    // Method to call the animation showing the enemy dieing
    public virtual void DieAnimation()
    {

    }
    #endregion
}