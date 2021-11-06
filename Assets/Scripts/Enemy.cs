using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerMain _player;
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    private SpriteRenderer _spriteRenderer;
    private bool isDied;
    void Start()
    {
        isDied = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D[] hitCols = Physics2D.OverlapCircleAll(transform.position, 15.0f);
        foreach (Collider2D collider in hitCols)
        {
            if (collider.GetComponent<PlayerMain>() != null)
            {
                _player = collider.GetComponent<PlayerMain>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDied)
        {
            Vector3 movement = _player.transform.position - transform.position;
            movement = Vector3.ClampMagnitude(new Vector3(movement.x, movement.y, 0), speed) * Time.deltaTime;
            transform.Translate(movement);
        }
    }
    public void ReactToHit()
    {
        StartCoroutine(Die());
    }
    public IEnumerator Die()
    {
        isDied = true;
        bool colorChanger = true;
        for (int i = 0; i < 4; i++)
        {
            colorChanger = !colorChanger;
            if (colorChanger)
                _spriteRenderer.color = Color.black;
            else _spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
        Destroy(gameObject);
    }
}
