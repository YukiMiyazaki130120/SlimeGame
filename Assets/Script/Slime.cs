using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime : MonoBehaviour
{
    Rigidbody2D Rg;
    Animator _animator;

    private Vector3 pos;
    private bool isDeath;
    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject GoalText;
    

    void Start()
    {
        Rg = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        pos = transform.position;
        if(isDeath){return;}
        if(Input.GetMouseButtonDown(0)){
            Rg.velocity = new Vector2(0,0);
            var power = new Vector2(300f,300f);
            Rg.AddForce(power);

            _animator.SetBool("isJump", true);
        }
        if(Rg.IsSleeping()){
            _animator.SetBool("isJump", false);
        }
        Fall();
    }

    private void Fall(){
        if(pos.y <= -10){
            isDeath = true;
            _animator.SetBool("isDeath", true);
            _animator.SetBool("isJump", false);
            GameOverText.SetActive(true);
            Invoke("ReplayGame", 1.5f);
        }
        else return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "needle" 
        || collision.gameObject.tag == "Enemy"){
            isDeath = true;
            _animator.SetBool("isDeath", true);
            _animator.SetBool("isJump", false);
            GameOverText.SetActive(true);
            Invoke("ReplayGame", 1.5f);
        }
        if(collision.gameObject.name == "Goal" && !GameOverText.activeSelf){
            _animator.SetBool("isJump", false);
            GoalText.SetActive(true);
            Invoke("ReplayGame", 1.5f);
        }
    }
    private void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
