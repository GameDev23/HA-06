using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    #region Fields
    public int Healthpoints;
    #endregion


    #region Methods
    // Called when attacking the player
    public virtual void Attack()
    {

    }

    // Called when enemy is defending itself 
    public virtual void Defend()
    {

    }

    // Called when enemy is charging
    public virtual void Charge()
    {

    }

    // Method to call the animation showing the enemy entering
    public virtual void EnterAnimation()
    {

    }


    // Method to call the animation showing the enemy leave the fight
    public virtual void LeaveAnimation()
    {

    }

    // Method to call the animation showing the enemy dieing
    public virtual void DieAnimation()
    {

    }
    #endregion
}