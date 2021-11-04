using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public PlayerMain _player;
    [SerializeField] public float speed;
    [SerializeField] public int hp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = _player.transform.position - transform.position;
        movement = Vector3.ClampMagnitude(new Vector3(movement.x, movement.y, 0), speed) * Time.deltaTime;
        transform.Translate(movement);
    }
}
