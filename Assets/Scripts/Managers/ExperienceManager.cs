using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// General Experience Manager for the player;
/// Implements Singleton Patern
/// </summary>
public class ExperienceManager : MonoBehaviour
{
    public ExperienceManager Instance { get; private set; }

    //Current Level
    [SerializeField]
    [Range(1,100)]
    private int Level=1;
    //Current Experience
    [SerializeField]
    private int currentExp=0;
    //Experience We Need For Next Level
    [SerializeField]
    private int ExperienceNedded;
    //Event for when we level up
    public UnityEvent OnLevelUp;

    //Base Experience for the first Level;
    private int levelBaseExperience = 100;

    //The Experience multiplier. DO NOT PUT OVER 1.1f;
    [SerializeField]
    [Range(1.01f,1.1f)]
    private float experienceMultiplier = 1.0681f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        ExperienceNedded = ExperienceFormula();
    }
    ///Experience Formula.
    ///Call when we level up to get the experience we need for the next level
    public int ExperienceFormula()
    {
        return (int)Mathf.Abs(levelBaseExperience * Mathf.Pow(experienceMultiplier, Level));
    }
    /// <summary>
    /// Call when you want to add Experience to the player.
    /// If we overcome the Experience we need to level up.
    /// We add a new level and invoke the event.
    /// </summary>
    /// <param name="experienceAmount"></param>
    public void GainExperience(int experienceAmount)
    {
        currentExp += experienceAmount;
        if (currentExp < ExperienceNedded)
        {
            return;
        }
        else
        {
            Level++;
            currentExp = currentExp - ExperienceNedded;
            ExperienceNedded = ExperienceFormula();

            OnLevelUp.Invoke();
        }
    }
}
