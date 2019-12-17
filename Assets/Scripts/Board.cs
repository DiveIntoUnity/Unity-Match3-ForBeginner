using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    //private Tile[,] m_TilesArray = new Tile[6, 6];
    private Dictionary<string, Tile> m_TilesDictionary = new Dictionary<string, Tile>();

    private GameObject m_TilePrefab;

    public int m_Width = 16;
    public int m_Height = 16; 

    // Start is called before the first frame update
    void Start()
    {
        m_TilePrefab = Resources.Load("Prefabs/CandyPurple") as GameObject;

        //Tile tile_0 = Instantiate(tilePrefab.transform.GetComponent<Tile>());
        //Instantiate(m_TilePrefab, transform.position, transform.rotation);

        //tile_0.transform.position = Vector3.zero;
        //tile_0.transform.parent = this.transform;
        CreateTiles();
    }

    /// <summary>
    /// Create new tiles using prefabs
    /// </summary>
    private void CreateTiles()
    {
        for (int y = 0; y < m_Height; y++)
        {
            for (int x = 0; x < m_Width; x++)
            {
                string key = x.ToString() + "," + y.ToString();

                Tile tile = Instantiate(m_TilePrefab.transform.GetComponent<Tile>());
                tile.transform.SetParent(this.transform);
                tile.transform.position = new Vector3(x, y, 0f);

                m_TilesDictionary.Add(key, tile);
            }
        }
    }

    public Tile GetTile(int x, int y)
    {
        string key = x.ToString() + "," + y.ToString();
        return m_TilesDictionary[key];
    }

    public Tile GetTile(string xy)
    {
        return m_TilesDictionary[xy];
    }
}
