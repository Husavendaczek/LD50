using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Achieving
{
    public class AchievementCreator : MonoBehaviour
    {
        public GameObject achievementPrefab;
        public Sprite[] sprites;

        public void Create(Achievement achievement, Transform parentTransform)
        {
            var achievementGameObject = Instantiate(achievementPrefab, parentTransform, true);
            achievementGameObject.name = achievement.AchievementType.ToString();
            achievementGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(-125, 75, 0);

            achievementGameObject.GetComponent<AchievementMono>().sprite.GetComponent<Image>().sprite = sprites[(int) achievement.AchievementType];
            achievementGameObject.GetComponent<AchievementMono>().title.GetComponent<TextMeshPro>().text = achievement.Title;
            achievementGameObject.GetComponent<AchievementMono>().message.GetComponent<TextMeshPro>().text = achievement.Message;
        }
    }
}