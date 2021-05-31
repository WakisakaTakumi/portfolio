using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dijkstra : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Vector2 Position;
    float SPEED = 4.0f;

    void FixedUpdate()
    {
        //二次元配列によるマップ
        int[,] map =
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0 },
                {0,1,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0 },
                {0,1,0,1,1,1,0,0,1,1,1,0,0,1,1,1,0,1,0,0,1,0 },
                {0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,1,0 },
                {0,1,0,0,0,0,1,0,0,0,1,0,0,1,1,1,0,0,0,0,1,0 },
                {0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0 },
                {0,1,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0 },
                {0,1,0,1,1,0,1,1,1,1,0,0,0,1,0,1,0,0,0,0,1,0 },
                {0,1,0,0,0,0,0,1,1,0,0,0,0,1,1,1,0,0,0,0,1,0 },
                {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0 },
                {0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0 },
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            };
        //距離の判定
        Vector2 goal = GameObject.Find("Masha-character-pack-free1_0").transform.position;
        int x = Mathf.FloorToInt(goal.x);
        int y = Mathf.FloorToInt(goal.y);
        y = -y - 1;
        map[y, x] = 3;
        rigidBody = GetComponent<Rigidbody2D>();
        
        for (int c = 3; c < 100; c++)
        {
            for (int j = 2; j < 20; j++)
            {
                for (int i = 2; i < 12; i++)
                {
                    if (map[i, j] == c)
                    {
                        if (map[i + 1, j] == 0)
                            map[i + 1, j] = c + 1;

                        if (map[i - 1, j] == 0)
                            map[i - 1, j] = c + 1;

                        if (map[i, j + 1] == 0)
                            map[i, j + 1] = c + 1;

                        if (map[i, j - 1] == 0)
                            map[i, j - 1] = c + 1;
    
                    }
                }
            }
        }
        
        //最短距離取得、移動
        Vector2 start = GameObject.Find("monster").transform.position;
        double m = start.x;
        double n = start.y;
        n = -n;
        int a = Mathf.FloorToInt(start.y);
        int b = Mathf.FloorToInt(start.x);
        a = -a - 1;
        Debug.Log(a);
        Debug.Log(b);
        if (a >= 12)
            a = 11;
        if (a <= 1)
            a = 2;
        if (b >= 20)
            b = 19;
        if (b <= 1)
            b = 2;
        Position.x = 0;
        Position.y = 0;
        
        if (m % 1 >=0.4 && m % 1 <= 0.6 && n % 1 >= 0.4 && n % 1 <= 0.6)
        {
            if (map[a + 1, b] == map[a, b] - 1)
            {
                a += 1;
                Position.y = -1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
            else if (map[a - 1, b] == map[a, b] - 1)
            {
                a -= 1;
                Position.y = 1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
            else if (map[a, b + 1] == map[a, b] - 1)
            {
                b += 1;
                Position.x = 1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
            else if (map[a, b - 1] == map[a, b] - 1)
            {
                b -= 1;
                Position.x = -1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
        }
        else if(GetComponent<Rigidbody2D>().IsSleeping())
        {
            double fix_x = m + 0.5;
            double fix_y = -n - 0.5;
            this.gameObject.transform.position = new Vector2((float)fix_x,(float)fix_y);
            
            if (map[a + 1, b] == map[a, b] - 1)
            {
                a += 1;
                Position.y = -1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
            else if (map[a - 1, b] == map[a, b] - 1)
            {
                a -= 1;
                Position.y = 1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
            else if (map[a, b + 1] == map[a, b] - 1)
            {
                b += 1;
                Position.x = 1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
            else if (map[a, b - 1] == map[a, b] - 1)
            {
                b -= 1;
                Position.x = -1;
                rigidBody.velocity = new Vector2(Position.x * SPEED, Position.y * SPEED);
            }
        }
    }
    
    //衝突判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
            double randomx = Random.Range(2, 19) + 0.5;
            double randomy = Random.Range(2, 11) + 0.5;
            this.gameObject.transform.position = new Vector2((float)randomx, (float)-randomy);
    }
}
