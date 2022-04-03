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
            achievementGameObject.transform.position = new Vector3(0, 0, 0); //TODO position right down

            achievementGameObject.GetComponent<AchievementMono>().sprite.GetComponent<Image>().sprite = sprites[(int) achievement.AchievementType];
            achievementGameObject.GetComponent<AchievementMono>().title.GetComponent<TextMeshPro>().text = achievement.Title;
            achievementGameObject.GetComponent<AchievementMono>().message.GetComponent<TextMeshPro>().text = achievement.Message;
        }
    }
}