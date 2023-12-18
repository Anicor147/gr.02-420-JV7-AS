using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Script.Runtime.LevelCreatorScript
{
    public class LevelCreatorScript : MonoBehaviour
    {
        [SerializeField] private string _levelFileName = "Level0";

        public string LevelFileName
        {
            get => _levelFileName;
            set => _levelFileName = value;
        }
        [SerializeField] private GameObject _wallPrefab;
        [SerializeField] private GameObject _gorillaPrefab;
        [SerializeField] private GameObject[] _itemsPrefabs;
        [SerializeField] private GameObject _grassPrefab;
        [SerializeField] private GameObject _homePrefab;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private GameObject _objectParent;
        [SerializeField]private GameObject _solidWall;
        private GameObject _player;

        private void Start()
        {
            _levelFileName = "Level" + GameObject.FindWithTag("LevelSelect").GetComponent<LevelSelector>().CurrentLevel;
            _player = GameObject.FindWithTag("Player");
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
                        InstantiateTile(_grassPrefab, j, -i);
                        char tile = line[j];
                        switch (tile)
                        {
                            case '!':
                                InstantiateTile(_solidWall,j,-i);
                                break;
                            case '#':
                                InstantiateTile(_wallPrefab, j, -i);
                                break;
                            case 'E':
                                InstantiateTile(_gorillaPrefab, j, -i);
                                break;
                            case 'P':
                                Vector3Int cellPosition = new Vector3Int(j, -i, 0);
                                Vector3 cellCenter = _tilemap.GetCellCenterWorld(cellPosition);
                                _player.transform.position = cellCenter;
                                break;
                            case 'F':
                                InstantiateTile(RandomItems(), j, -i);
                                break;
                            case 'I':
                                 InstantiateTile(_homePrefab, j, -i);
                                break;
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

            Instantiate(prefab, cellCenter, Quaternion.identity, _objectParent.transform);
        }


        private GameObject RandomItems()
        {
            int randomIndex = Random.Range(0, _itemsPrefabs.Length);
            GameObject itemPrefab = _itemsPrefabs[randomIndex];

            return itemPrefab;
        }
    }
}
