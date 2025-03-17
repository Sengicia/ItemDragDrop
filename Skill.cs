using UnityEngine;
[System.Serializable]


    
    public class Skill
    {
        public string skillName;
        public int level;
        public float currentXP;
        public float xpRequiredForNextLevel;

        public void AddXP(float xp)
        {
            currentXP += xp;
            if (currentXP >= xpRequiredForNextLevel)
            {
                level++;
                currentXP -= xpRequiredForNextLevel;
                xpRequiredForNextLevel = CalculateXPForNextLevel();
                // Optionally: Trigger a level-up event
            }
        }

        private float CalculateXPForNextLevel()
        {
            // Example: XP required increases by 20% each level
            return xpRequiredForNextLevel * 1.2f;
        }
    }


