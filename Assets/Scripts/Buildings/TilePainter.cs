using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePainter : MonoBehaviour
{
    public Tilemap tilemap;     // Assign in Inspector
    public TileBase grassTile;  // Drag in your grass Tile

    public int width = 10;
    public int height = 10;

    void Start()
    {
        FillAreaWithGrass(Vector3Int.zero, width, height);
    }

    void FillAreaWithGrass(Vector3Int startPosition, int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int position = new Vector3Int(startPosition.x + x, startPosition.y + y, 0);
                tilemap.SetTile(position, grassTile);
            }
        }
    }
}
