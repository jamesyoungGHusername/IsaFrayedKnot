using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
public class Cartographer : MonoBehaviour {
    public Tilemap floor;
    public Tilemap wall;
    public TileBase floorTile;
    public TileBase wallTile;
    private int[,] intMap;
    private int[,] wallMap;
    private Room testRoom;

    // Start is called before the first frame update
    void Start() {
        //intMap = GenFloorArr(15, 11, false);
        //wallMap = GenWallArr(15, 11);
        //RenderMap(intMap, floor, floorTile);
        //RenderMap(wallMap, wall, wallTile);
        GenerateRoomAt(0, 0);
        //GenerateRoomAt(0, 10);
        //GenerateRoomAt(0, -10);
        //GenerateRoomAt(15, 0);
        //GenerateRoomAt(-15, 0);
        //testRoom = new Room(new List<Direction> { Direction.East, Direction.North, Direction.South, Direction.West },0,0);

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


    public void GenerateRoomAt(int x,int y) {
        intMap = GenFloorArr(6, 6, false);
        wallMap = GenWallArr(6, 6);
        RenderMap(intMap, floor, floorTile,x,y);
        RenderMap(wallMap, wall, wallTile,x,y);
    }



    public int[,] GenWallArr(int width, int height) {
        //x mod width || y mod height

        int[,] map = new int[width, height];
        for (int x = 0; x <= map.GetUpperBound(0); x++) {
            for (int y = 0; y <= map.GetUpperBound(1); y++) {

                if (x % (width-2) == 0 || y % (height-2)==0) {
                    map[x, y] = 1;
                }
            }
        }

        return map;
    }

    public static int[,] GenFloorArr(int width,int height,bool empty) {
        int[,] map = new int[width, height];
        for (int x = 0; x <= map.GetUpperBound(0); x++) {
            for (int y = 0; y <= map.GetUpperBound(1); y++) {
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
    public static void RenderMap(int[,] map, Tilemap tilemap, TileBase tile,int xOffset,int yOffset) {

        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1) {
                    tilemap.SetTile(new Vector3Int(x+xOffset, y+yOffset, 0), tile);
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

    public void genRooms(Room root) {

    }
}

public class Room {
    int doorNum;
    Direction[] doorLocations;
    int x;
    int y;
    public Room(List<Direction> possibleDoors,int x,int y) {
        doorNum = Random.Range(0,possibleDoors.Count);
        doorLocations = new Direction[doorNum];
        for (int i = 0; i < possibleDoors.Count-1 ; i++) {
            
            int doorIndex = Random.Range(0, possibleDoors.Count-1);
            doorLocations[i] = possibleDoors[doorIndex];
            possibleDoors.RemoveAt(doorIndex);
        }
        this.x = x;
        this.y = y;
        foreach (Direction d in doorLocations) {
            Debug.Log(d);
        }
    }
}
public class Floor {
    List<Room> rooms;
    int width, height,maxRooms;
    public Floor(int maxRooms,int width,int height) {
        this.width = width;
        this.height = height;
        this.maxRooms = maxRooms;
    }
}
public enum Direction {
    North,
    South,
    East,
    West
}

