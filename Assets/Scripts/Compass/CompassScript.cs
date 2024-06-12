using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Compass
{
    public class CompassScript : MonoBehaviour
    {
        public RawImage compassImage;
        public Transform player;

        public GameObject iconPrefab;
        List<QuestMarker> questMarkers = new List<QuestMarker>();
        public float maxDistance = 150f;

        float compassUnit;
        public QuestMarker one;
        public QuestMarker two;
        public QuestMarker three;


        private void Start()
        {
            compassUnit = compassImage.rectTransform.rect.width / 360f;
            AddQuestMarker(one);
            AddQuestMarker(two);
            AddQuestMarker(three);
        }


        void Update()
        {
            compassImage.uvRect = new(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

            foreach (QuestMarker marker in questMarkers)
            {
                marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);

                float dist = Vector2.Distance(new(player.transform.position.x, player.transform.position.z), marker.position);
                float scale = 0f;

                if (dist < maxDistance)
                    scale = 1f - (dist / maxDistance);

                // Do something depending on the marker's distance to the object.
                Color tempcolor = marker.image.color;
                tempcolor.a = scale;
                marker.image.color = tempcolor;
            }
        }

        public void AddQuestMarker(QuestMarker marker)
        {
            GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
            marker.image = newMarker.GetComponent<Image>();
            marker.image.sprite = marker.icon;
            questMarkers.Add(marker);
        }

        Vector2 GetPosOnCompass(QuestMarker marker)
        {
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
            Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

            float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);
            return new Vector2(compassUnit * angle, 0f);
        }
    }
} 