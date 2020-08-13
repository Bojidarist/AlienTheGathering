using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ATG.Controllers;
using ATG.Core;

namespace ATG.Utilities
{
    public class EnemySpawner : MonoBehaviour
    {
        private ScreenBorderDetector borderDetector = default;
        [SerializeField] private GameObject cowPrefab = default;
        [SerializeField] private GameObject ninjaPrefab = default;

        void Start()
        {
            borderDetector = FindObjectOfType<ScreenBorderDetector>();
            if(SceneManager.GetActiveScene().name == SceneNames.CowLevel)
            {
                for (int i = 0; i < ATGConfig.EnemyCount; i++)
                {
                    Instantiate(cowPrefab, new Vector3(Random.Range(borderDetector.leftBorder, borderDetector.rightBorder), -4.4f, 0f), Quaternion.identity);
                }
            }
            else if(SceneManager.GetActiveScene().name == SceneNames.GrassLevel)
            {
                for (int i = 0; i < ATGConfig.EnemyCount; i++)
                {
                    var enemy = Instantiate(ninjaPrefab, new Vector3(Random.Range(borderDetector.leftBorder, borderDetector.rightBorder), 0f, 0f), Quaternion.identity);
                    var enemyCtrl = enemy.GetComponent<NinjaController>();
                    enemyCtrl.player = FindObjectOfType<AlienController>();
                }
            }
        }

        void Update()
        {
            if (SceneManager.GetActiveScene().name == SceneNames.CowLevel)
            {   
                if (FindObjectsOfType<CowController>().Length == 0)
                {
                    GameManager.Instance.sceneChanger.Change(SceneNames.GrassLevel);
                    ATGConfig.EnemyCount += 1;
                }            
            }
            else if(SceneManager.GetActiveScene().name == SceneNames.GrassLevel)
            {
                if (FindObjectsOfType<NinjaController>().Length == 0)
                {
                    GameManager.Instance.sceneChanger.Change(SceneNames.CowLevel);
                    ATGConfig.EnemyCount += 1;
                } 
            }
        }
    }
}
