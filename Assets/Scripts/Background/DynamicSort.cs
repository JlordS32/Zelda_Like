using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DynamicSort : MonoBehaviour
{
    [SerializeField] private string _sortingLayerName = "Background";

    // References
    private TilemapRenderer[] _children;

    private void Awake()
    {
        // Initialise Game Object array
        int childCount = transform.childCount;
        _children = new TilemapRenderer[childCount];

        for (int i = 0; i < childCount; i++)
        {
            _children[i] = transform.GetChild(i).GetComponent<TilemapRenderer>();
        }

        // Start sorting
        SortLayerBasedOnIndex(_children);
    }

    private void SortLayerBasedOnIndex(TilemapRenderer[] objects)
    {
        int sortingOrder = objects.Length; 

        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
            {
                // Assign sorting layer name
                objects[i].sortingLayerName = _sortingLayerName;

                // Assign sorting order (decreasing)
                objects[i].sortingOrder = sortingOrder;
                sortingOrder--;
            }
        }
    }

}
