using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    Vector2Int currentTilesPos = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePos;
    Vector2Int onTileGridPlayerPos;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    public void Add(GameObject tileGameObject, Vector2Int tilePos)
    {
        terrainTiles[tilePos.x, tilePos.y] = tileGameObject;
    }

    private void Awake()
    {
        terrainTiles= new GameObject[terrainTileHorizontalCount,terrainTileVerticalCount];
    }
    private void Start()
    {
        UpdateTileOnScreen();
    }
    void Update()
    {
        playerTilePos.x = (int)(playerTransform.position.x/ tileSize);
        playerTilePos.y = (int)(playerTransform.position.y/ tileSize);

        playerTilePos.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePos.y -= playerTransform.position.y < 0 ? 1 : 0;
       
        if (currentTilesPos != playerTilePos)
        {
            currentTilesPos = playerTilePos;

            onTileGridPlayerPos.x = CalculatePosOnAxis(onTileGridPlayerPos.x, true);
            onTileGridPlayerPos.y = CalculatePosOnAxis(onTileGridPlayerPos.y, false);
            UpdateTileOnScreen();
        }
    }

    private void UpdateTileOnScreen()
    {
        for(int pov_x = -(fieldOfVisionWidth/2); pov_x <= fieldOfVisionWidth/2; pov_x++)
        {
            for(int pov_y = -(fieldOfVisionHeight/2);pov_y<= fieldOfVisionHeight/2; pov_y++)
            {
                int TileToUpdate_x = CalculatePosOnAxis(playerTilePos.x+pov_x, true);
                int TileToUpdate_y = CalculatePosOnAxis(playerTilePos.y +pov_y, false);

               

                GameObject tile = terrainTiles[TileToUpdate_x, TileToUpdate_y];
               Vector3 newPos = CalculateTilePos(
                    playerTilePos.x +pov_x,
                    playerTilePos.y +pov_y);
                if (newPos != tile.transform.position)
                {
                    tile.transform.position = newPos;
                    terrainTiles[TileToUpdate_x, TileToUpdate_y].GetComponent<TerrainTile>().Spawn();
                }
            }
        }
    }

    private Vector3 CalculateTilePos(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePosOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount-1  + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount -1  + currentValue % terrainTileVerticalCount;
            }
        }
        return (int)currentValue;
    }
}
