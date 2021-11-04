using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    private Rigidbody2D _body;
    private Animator _anim;
    public float impulsePower;
    private float deltaX;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_body.velocity.x == 0 && Input.GetAxis("Horizontal") != 0)
        {
            deltaX = Mathf.Sign(Input.GetAxis("Horizontal")) * impulsePower /*Time.deltaTime **/;
            Vector2 movement = new Vector2(deltaX, _body.velocity.y);
            transform.localScale = new Vector3(Mathf.Sign(deltaX)*Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            _body.velocity = movement;
            _anim.SetBool("IsAttack", true);
            StartCoroutine(Force());
        }
    }
    public IEnumerator Force()
    {
        yield return new WaitForSeconds(0.7f);
        _body.velocity = Vector3.zero;
        _anim.SetBool("IsAttack", false);
    }
}
