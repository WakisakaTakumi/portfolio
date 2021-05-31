using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {
    // Start is called before the first frame update
    Animator animator;
    void Start(){
        this.animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update(){
        if (Input.anyKeyDown){
            Vector2? action = this.actionKeyDown();
            if (action.HasValue) {
                setStateToAnimetor(vector: action.Value);
                return;
            }
        }
        Vector2 vector = new Vector2(
            (int)Input.GetAxis("Horizontal"), (int)Input.GetAxis("Vertical"));
        setStateToAnimetor(vector: vector != Vector2.zero ? vector : (Vector2?)null);
    }
    private void setStateToAnimetor(Vector2 ? vector){
        if (!vector.HasValue) {
            this.animator.speed = 0.0f;
            return;
        }
        Debug.Log(vector.Value);
        if (!Input.GetKey(KeyCode.LeftShift)) {
            this.animator.speed = 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftShift)){
            this.animator.speed = 2.0f;
        }
        this.animator.SetFloat("x", vector.Value.x);
        this.animator.SetFloat("y", vector.Value.y);
    }
    private Vector2? actionKeyDown() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) return Vector2.up;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return Vector2.left;
        if (Input.GetKeyDown(KeyCode.DownArrow)) return Vector2.down;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return Vector2.right;
        return null;
    }
}
