using UnityEngine;
using System.Collections.Generic;

public class ItemGridGenerator : MonoBehaviour
{
    public GridNode NodePrefab;
    public int Row = 5, Col = 5;

    private void Start()
    {
        
    }

    public List<GameObject> GenerateGrid()
    {
        List<GameObject> temp = new List<GameObject>();
        List<Vector3> spawnPos = new List<Vector3>();
        for (int y = 0; y < Col; y++)
        {
            for (int x = 0; x < Row; x++)
            {
                var spawnPosition = transform.position + new Vector3(x,0,y); //Still need to orientation
                var node = Instantiate(NodePrefab, spawnPosition, Quaternion.identity);

                node.transform.SetParent(transform);
                temp.Add(node.transform.gameObject);
            }
        }

        return temp;
    }
}
