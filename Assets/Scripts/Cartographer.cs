using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Cartographer : MonoBehaviour
{
    public Tilemap floor;
    public Tilemap wall;
    public TileBase floorTile;
    public TileBase wallTile;
    private int[,] intMap;
    private int[,] wallMap;


    // Start is called before the first frame update
    void Start()
    {
        intMap = GenFloorArr(15, 11, false);
        wallMap = GenWallArr(15, 11);
        RenderMap(intMap, floor, floorTile);
        RenderMap(wallMap, wall, wallTile);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var test = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(test);
            var tilePos = floor.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            floor.SetTile(tilePos, floorTile);
        }
    }

    public int[,] GenWallArr(int width, int height) {
        //x mod width || y mod height
        
        int[,] map = new int[width, height];

        Debug.Log("Max x val: " + map.GetUpperBound(0));
        Debug.Log("Max y val: " + map.GetUpperBound(1));
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                Debug.Log(x);
                Debug.Log(width);
                if ((x + 1) % width == 0) {
                    map[x, y] = 1;
                }
            }
        }

        return map;
    }

    public static int[,] GenFloorArr(int width,int height,bool empty) {
        int[,] map = new int[width, height];
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                if (empty) {
                    map[x, y] = 0;
                } else {
                    map[x, y] = 1;
                }
            }
        }
        return map;
    }
    public static void RenderMap(int[,] map,Tilemap tilemap,TileBase tile) {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();
        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1) {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }
    public static void UpdateMap(int[,] map, Tilemap tilemap) //Takes in our map and tilemap, setting null tiles where needed
{
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                //We are only going to update the map, rather than rendering again
                //This is because it uses less resources to update tiles to null
                //As opposed to re-drawing every single tile (and collision data)
                if (map[x, y] == 0) {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }



}
