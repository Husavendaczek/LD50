using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Achieving
{
    public class AchievementManager : MonoBehaviour
    {
        public AchievementCreator achievementCreator;
        public Transform gameCanvasTransform;
        
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
            }
        };

        public void CompleteAchievement(AchievementType achievementType)
        {
            var achieved =
                _allAchievements.FirstOrDefault(achievement => achievement.AchievementType == achievementType);
            if(achieved == null) return;
            
            achieved.Achieved = true;

            ShowAchievement(achieved);
        }

        private void ShowAchievement(Achievement achievement)
        {
            if(achievement.Achieved) return;
            achievementCreator.Create(achievement, gameCanvasTransform);
        }

        public List<Achievement> CompleteAchievements()
        {
            return _allAchievements.Where(achievement => achievement.Achieved == true).ToList();
        }
    }
}