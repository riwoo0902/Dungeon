using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace PathFind.MapData
{
    
    public class MapData : MonoBehaviour
    {

        [SerializeField] private Tilemap[] tilemaps;
        public static Dictionary<Vector3Int, MovableData> mapData { get; private set; } = new();
        private Vector3Int[] _allMoveDir = 
        { 
            new Vector3Int(-1, 1), new Vector3Int(0, 1), new Vector3Int(1, 1),
            new Vector3Int(-1, 0),new Vector3Int(1, 0),
            new Vector3Int(-1, -1),new Vector3Int(0, -1),new Vector3Int(1, -1)
        };


        private BoundsInt _mapSize = new();

        public static MapData instance;
        private void Awake()
        {
            if (instance != null) Destroy(gameObject);
            else instance = this;

            ResetMapData();
        }

        public void ResetMapData()
        {
            //리셋
            mapData = new();

            //맵 데이터로 만들기
            foreach (Tilemap tilemap in tilemaps)
            {
                BoundsInt bounds = tilemap.cellBounds;

                for (int x = bounds.xMin; x < bounds.xMax; x++)
                {
                    for (int y = bounds.yMin; y < bounds.yMax; y++)
                    {
                        Vector3Int pos = new Vector3Int(x, y, 0);
                        if (tilemap.HasTile(pos))
                        {
                            if (!mapData.TryGetValue(pos, out MovableData value))
                            {
                                 mapData.Add(pos, new MovableData());
                            }

                            if (_mapSize.xMin > x) _mapSize.xMin = x;
                            if (_mapSize.xMax < x) _mapSize.xMax = x;
                            if (_mapSize.yMin > y) _mapSize.yMin = y;
                            if (_mapSize.yMax < y) _mapSize.yMax = y;
                        }
                    }
                }



            }

            //타일마다 이동가능한 방향구하기

            for (int x = _mapSize.xMin; x <= _mapSize.xMax; x++)
            {
                for (int y = _mapSize.yMin; y <= _mapSize.yMax; y++)
                {
                    Vector3Int pos = new Vector3Int(x, y, 0);
                    if(mapData.TryGetValue(pos, out MovableData value))
                    {
                        foreach(Vector3Int dir in _allMoveDir)
                        {
                            value.movableData.Add(dir, mapData.TryGetValue(pos + dir, out MovableData value2));
                            
                        }
                    }

                    #region 검사용
                    Debug.Log(pos);
                    if(value != null)
                    {
                        foreach (Vector3Int dir in _allMoveDir)
                        {
                            value.movableData.TryGetValue(dir, out bool a);
                            Debug.Log(a);
                        }
                    }
                    else Debug.Log("This pos is null");
                    #endregion
                }
            }
        }

        public class MovableData
        {
            public Dictionary<Vector3Int, bool> movableData = new();
        }

    }
}

