using UnityEngine;
using System.Collections.Generic;
public class Player_Skills : MonoBehaviour
{
    
    public List<Skill> skills;

    void Start()
    {
        // Initialize skills with starting XP and levels
        skills = new List<Skill>
        {
            new Skill { skillName = "Woodcutting", level = 1, currentXP = 0, xpRequiredForNextLevel = 100 },
            new Skill { skillName = "Mining", level = 1, currentXP = 0, xpRequiredForNextLevel = 100 }
        };
    }

    public void GainXP(string skillName, float xp)
    {
        Skill skill = skills.Find(s => s.skillName == skillName);
        if (skill != null)
        {
            skill.AddXP(xp);
            // Optionally, update the UI here to reflect changes
        }
    }

}
