using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "UniqueTile", menuName = "Tiles/UniqueTile")]
public class UniqueTile : Tile
{

    public Color uniqueColor = Color.white;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        tileData.color = uniqueColor;

    }


    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {

        Debug.Log("UniqueTile activated at position: " + position);


        return base.StartUp(position, tilemap, go);
    }
}
