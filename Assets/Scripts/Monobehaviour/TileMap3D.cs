using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.Tilemaps;

public class TileMap3D : MonoBehaviour
{
    public Tile3D[,,] tiles = new Tile3D[0, 0, 0];

    public float tileSize = 1;
}

#if UNITY_EDITOR
[CustomEditor(typeof(TileMap3D))]
public class TileMap3DEditor : Editor
{
    private TileMap3D tileMap;

    Vector3Int mapSize;

    public override void OnInspectorGUI()
    {
        tileMap = (TileMap3D)target;
        //base.OnInspectorGUI();
        mapSize = new Vector3Int(tileMap.tiles.GetLength(0), tileMap.tiles.GetLength(1), tileMap.tiles.GetLength(2));
        mapSize = EditorGUILayout.Vector3IntField($"Map Size: ", mapSize);

        Tile3D[,,] tempTiles = new Tile3D[mapSize.x, mapSize.y, mapSize.z];
        Vector3Int smallests = new Vector3Int(
            Math.Min(tileMap.tiles.GetLength(0), tempTiles.GetLength(0)),
            Math.Min(tileMap.tiles.GetLength(1), tempTiles.GetLength(1)),
            Math.Min(tileMap.tiles.GetLength(2), tempTiles.GetLength(2))
            );

        Handles.color = Color.white;

        for (int i = 0; i < smallests.x; i++)
        {
            for (int j = 0; j < smallests.y; j++)
            {
                for (int k = 0; k < smallests.z; k++)
                {
                }
            }
        }

        //checagem da mudanca de size

        tileMap.tiles = tempTiles;

        foreach (Tile3D tile in tileMap.tiles)
        {
            if (!tile) continue;
            Handles.DrawWireCube(tile.transform.position, Vector3.one * tileMap.tileSize);
        }

        EditorGUILayout.LabelField($"{tileMap.tiles.GetLength(0)}x{tileMap.tiles.GetLength(1)}x{tileMap.tiles.GetLength(2)}");

    }
}
#endif