using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "PlatformTile", menuName = "Tiles/Platform Tile")]
public class PlatformTile : Tile
{

    public Color platformColor = Color.white;


    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {

        base.GetTileData(position, tilemap, ref tileData);

        tileData.color = platformColor;

        tileData.colliderType = ColliderType.Sprite;
    }


    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {

        if (go != null)
        {

            Collider2D collider = go.GetComponent<Collider2D>();
            if (collider == null)
            {
                collider = go.AddComponent<BoxCollider2D>();
            }
           
            if (collider is BoxCollider2D boxCollider)
            {
                boxCollider.usedByEffector = true;
            }


            if (go.GetComponent<PlatformEffector2D>() == null)
            {
                PlatformEffector2D effector = go.AddComponent<PlatformEffector2D>();
                effector.useOneWay = true;          
                effector.surfaceArc = 180f;        
            }
        }
        return base.StartUp(position, tilemap, go);
    }
}

