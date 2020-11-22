using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // キューブ接触時の効果音
    private AudioSource cubeSe;

    // Use this for initialization
    void Start()
    {
        this.cubeSe = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // キューブが重なるときと地面に接触したときに効果音を鳴らす
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "Cube")
        {
            this.cubeSe.Play();
        }
    }
}