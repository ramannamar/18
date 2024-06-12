using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class CompassScript : MonoBehaviour
{
    public RawImage compassImage;
    public Transform player;

    public GameObject iconPrefab;
    List<QuestMarker> questMarkers = new List<QuestMarker>();

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


    private void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach (QuestMarker marker in questMarkers)
        {
            marker.image.rectTransform.rect.width / 360f;
        }

    }

    public void AddQuestMarker(QuestMarker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>;
        marker.image.sprite = marker.icon;
        questMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(QuestMarker marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 markerFwd = new Vector2(marker.transform.forward.x, marker.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, markerFwd);
        return new Vector2(compassUnit * angle, 0f);
    }
}