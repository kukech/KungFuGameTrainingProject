using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] backgrounds;
    [SerializeField] private PlayerMain _player;
    private float stepXrepeat = 12.8f;
    private float secondMaxRepeatBorder;
    private float secondMinRepeatBorder;
    private int activeBackground;
    [SerializeField] private Enemy[] _enemies;
    Enemy enemy;
    void Start()
    {
        secondMaxRepeatBorder = 6.4f;
        secondMinRepeatBorder = -6.4f;
        activeBackground = 1;
        enemy = Instantiate(_enemies[0]);
        enemy.transform.position = new Vector3(_player.transform.position.x + 8, Random.Range(-1.2f, -3.5f), 0);
    }
    void Update()
    {
        if(_player.transform.position.x > secondMaxRepeatBorder)
        {
            switch (activeBackground)
            {
                case 0 :
                    backgrounds[2].transform.position = new Vector3(backgrounds[2].transform.position.x + stepXrepeat * 3,
                                                                    backgrounds[2].transform.position.y,
                                                                    backgrounds[2].transform.position.z);
                    secondMaxRepeatBorder += stepXrepeat;
                    secondMinRepeatBorder += stepXrepeat;
                    activeBackground = 1;
                    break;
                case 1:
                    backgrounds[0].transform.position = new Vector3(backgrounds[0].transform.position.x + stepXrepeat * 3,
                                                                    backgrounds[0].transform.position.y,
                                                                    backgrounds[0].transform.position.z);
                    secondMaxRepeatBorder += stepXrepeat;
                    secondMinRepeatBorder += stepXrepeat;
                    activeBackground = 2;
                    break;
                case 2:
                    backgrounds[1].transform.position = new Vector3(backgrounds[1].transform.position.x + stepXrepeat * 3,
                                                                    backgrounds[1].transform.position.y,
                                                                    backgrounds[1].transform.position.z);
                    secondMaxRepeatBorder += stepXrepeat;
                    secondMinRepeatBorder += stepXrepeat;
                    activeBackground = 0;
                    break;
            }
        }
        if (_player.transform.position.x < secondMinRepeatBorder)
        {
            switch (activeBackground)
            {
                case 0:
                    backgrounds[1].transform.position = new Vector3(backgrounds[1].transform.position.x - stepXrepeat * 3,
                                                                    backgrounds[1].transform.position.y,
                                                                    backgrounds[1].transform.position.z);
                    secondMaxRepeatBorder -= stepXrepeat;
                    secondMinRepeatBorder -= stepXrepeat;
                    activeBackground = 2;
                    break;
                case 1:
                    backgrounds[2].transform.position = new Vector3(backgrounds[2].transform.position.x - stepXrepeat * 3,
                                                                    backgrounds[2].transform.position.y,
                                                                    backgrounds[2].transform.position.z);
                    secondMaxRepeatBorder -= stepXrepeat;
                    secondMinRepeatBorder -= stepXrepeat;
                    activeBackground = 0;
                    break;
                case 2:
                    backgrounds[0].transform.position = new Vector3(backgrounds[0].transform.position.x - stepXrepeat * 3,
                                                                    backgrounds[0].transform.position.y,
                                                                    backgrounds[0].transform.position.z);
                    secondMaxRepeatBorder -= stepXrepeat;
                    secondMinRepeatBorder -= stepXrepeat;
                    activeBackground = 1;
                    break;
            }
        }
    }
}
