using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    [SerializeField] Image image;

    private Item item;
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = item.icon;
                image.enabled = true;
            }
        }
    }

    private void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }
}
