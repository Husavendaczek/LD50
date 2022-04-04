using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Achieving
{
    public class ResultAchievements : MonoBehaviour
    {
        public GameObject ResultPrefab;

        public void ShowAchievements(List<Achievement> achievements)
        {
            foreach (var achievement in achievements)
            {
                var newAch = Instantiate(ResultPrefab, transform, true);
                newAch.GetComponent<AchievementMono>().title.GetComponent<TextMeshProUGUI>().text = achievement.Title;
                newAch.GetComponent<AchievementMono>().message.GetComponent<TextMeshProUGUI>().text = achievement.Message;
            }
        }
    }
}