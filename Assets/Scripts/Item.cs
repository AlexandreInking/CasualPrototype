using UnityEngine;

public enum QualityType
{
    CURSED,
    BROKEN,
    COMMON,
    RARE,
    UNIQUE,
    LEGENDARY,
    MYTHIC
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/New Item")]
public class Item : ScriptableObject
{
    public string name;
    public Sprite icon;
    public QualityType quality;
    public int statQuantity;
    public float mass;

}
