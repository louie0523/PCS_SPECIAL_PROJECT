using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Color ColorFloor = Color.white;
    public Color ColorWall = Color.red;
    // 적 등장 위치
    public Color ColorResponse = new Color(64, 128, 128);

    public Transform Terrain;
    public Texture2D Mapinfo;
    public float titleSize = 4.0f;
    private int mapWidth;
    private int mapHeight;
    public GameObject Floor;
    public GameObject Wall;
    public GameObject Floor_Response;

    public void BuildGenerator()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        mapWidth = Mapinfo.width;
        mapHeight = Mapinfo.height;

        Color[] pixels = Mapinfo.GetPixels();

        for(int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                Color pixelColor = pixels[i * mapWidth + j];
                Debug.Log(pixelColor);
                if (pixelColor == ColorFloor)
                {
                    GameObject floor = GameObject.Instantiate(Floor, Terrain);
                    floor.transform.position = new Vector3(j * titleSize, 0, i * titleSize);
                }
                if (pixelColor == ColorWall)
                {
                    GameObject wall = GameObject.Instantiate(Wall, Terrain);
                    wall.transform.position = new Vector3(j * titleSize, 0, i * titleSize);
                }
                if(pixelColor == ColorResponse)
                {
                    GameObject floor = GameObject.Instantiate(Floor_Response, Terrain);
                    floor.transform.position = new Vector3(j * titleSize, 0, i * titleSize);
                }

            }

        } 
    }
}
