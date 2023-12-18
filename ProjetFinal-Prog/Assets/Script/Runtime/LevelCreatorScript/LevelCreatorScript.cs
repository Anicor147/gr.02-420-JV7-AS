using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Script.Runtime.LevelCreatorScript
{
    public class LevelCreatorScript : MonoBehaviour
    {
        [SerializeField] private string _levelFileName = "Level0";
        [SerializeField] private GameObject _wallPrefab;
        [SerializeField] private GameObject _gorillaPrefab;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject[] _chickenPrefabs;

        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private GameObject _objectParent;
        private void Start()
        {
            CreateLevel();
        }


        private void CreateLevel()
        {
            var levelText = Resources.Load<TextAsset>(_levelFileName);

            if (levelText != null)
            {
                string[] lines = levelText.text.Split('\n');

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    for (int j = 0; j < line.Length; j++)
                    {
                        char tile = line[j];
                        if (tile == '#')
                        {
                            InstantiateTile(_wallPrefab, j, -i);
                        }
                        else if (tile == 'E')
                        {
                            InstantiateTile(_gorillaPrefab, j, -i);
                        }
                        else if (tile == 'P')
                        {
                            InstantiateTile(_playerPrefab, j, -i);
                        }
                        else if (tile == 'F')
                        {
                            InstantiateTile(RandomChicken(), j, -i);
                        }
                        else if (tile == 'I')
                        {
                            // InstantiateTile(_homePrefab, j, -i);
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("Level file not found: " + _levelFileName);
            }
        }


        private void InstantiateTile(GameObject prefab, int x, int y)
        {
            Vector3Int cellPosition = new Vector3Int(x, y, 0);
            Vector3 cellCenter = _tilemap.GetCellCenterWorld(cellPosition);

            Instantiate(prefab, cellCenter, Quaternion.identity , _objectParent.transform);
        }


        private GameObject RandomChicken()
        {
            int randomIndex = Random.Range(0, _chickenPrefabs.Length);
            GameObject chickenPrefab = _chickenPrefabs[randomIndex];

            return chickenPrefab;
        }
    }
}
