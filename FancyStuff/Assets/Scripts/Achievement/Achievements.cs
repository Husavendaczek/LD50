using System.Collections.Generic;
using UnityEngine;

namespace Achievement
{
    public class Achievements : MonoBehaviour
    {
        public List<Sprite> sprites;

        private List<AchievementComponent> _completeAchievements = new List<AchievementComponent>();
        
        private AchievementComponent cleanedUpStevesRoom = new AchievementComponent
        {
            Title = "Clean",
            Text = "Cleaned up Steves room",
            ImageValue = 0,
            Achieved = false
        };

        public void AchieveStevesRoom()
        {
            cleanedUpStevesRoom.Achieved = true;
            _completeAchievements.Add(cleanedUpStevesRoom);
        }

        public List<AchievementComponent> CompleteAchievements()
        {
            return _completeAchievements;
        }
    }
}