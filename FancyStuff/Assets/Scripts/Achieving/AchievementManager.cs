using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Achieving
{
    public class AchievementManager : MonoBehaviour
    {
        public AchievementCreator achievementCreator;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private readonly List<Achievement> _allAchievements = new()
        {
            new Achievement
            {
                AchievementType = AchievementType.CleanedStevesRoom,
                Title = "Clean",
                Message = "Cleaned up Steves room",
                Achieved = false
            },
            new Achievement
            {
                AchievementType = AchievementType.NatureLover,
                Title = "Nature Lover",
                Message = "You really love the nature",
                Achieved = false
            },
            new Achievement
            {
                AchievementType = AchievementType.CatDresser,
                Title = "Cat Dresser",
                Message = "I don't  know if the cat likes it",
                Achieved = false
            },
            new Achievement
            {
                AchievementType = AchievementType.GrandmaKiller,
                Title = "Grandma Killer",
                Message = "You really give a sh**",
                Achieved = false
            },
            new Achievement
            {
                AchievementType = AchievementType.CatKiller,
                Title = "Cat Killer",
                Message = "You really give a sh**",
                Achieved = false
            }
        };

        public void CompleteAchievement(AchievementType achievementType)
        {
            var achieved =
                _allAchievements.FirstOrDefault(achievement => achievement.AchievementType == achievementType);

            if(achieved == null) return;
            
            if(achieved.Achieved) return;
            
            achieved.Achieved = true;

            ShowAchievement(achieved);
        }

        private void ShowAchievement(Achievement achievement)
        {
            if(!achievement.Achieved) return;
            var gameCanvas = GameObject.FindWithTag("GameCanvas");
            achievementCreator.Create(achievement, gameCanvas.transform);
        }

        public List<Achievement> CompleteAchievements()
        {
            return _allAchievements.Where(achievement => achievement.Achieved == true).ToList();
        }
    }
}