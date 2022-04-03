using System.Collections;
using TMPro;
using UnityEngine;

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

            // TODO add image for achievement
            // achievementGameObject.GetComponent<AchievementMono>().sprite.GetComponent<Image>().sprite = sprites[(int) achievement.AchievementType];
            achievementGameObject.GetComponent<AchievementMono>().title.GetComponent<TextMeshProUGUI>().text = achievement.Title;
            achievementGameObject.GetComponent<AchievementMono>().message.GetComponent<TextMeshProUGUI>().text = achievement.Message;


            StartCoroutine(ShowAchievement(achievementGameObject));

        }
        
        private IEnumerator ShowAchievement(GameObject achievement)
        {
            achievement.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            
            achievement.gameObject.SetActive(false);
            Destroy(achievement.gameObject);
        }
    }
}