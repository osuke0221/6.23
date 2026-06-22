using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;          // 下方向のスピード
    public float moveRange = 2f;      // 左右の揺れ幅
    public float moveSpeed = 2f;      // 左右の揺れスピード
    public float randomTurnTime = 1f; // ランダム方向転換の間隔

    float timer = 0f;
    float randomX = 0f;

    void Start()
    {
        // 最初のランダム方向
        randomX = Random.Range(-1f, 1f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 一定時間ごとにランダム方向に変える
        if (timer > randomTurnTime)
        {
            randomX = Random.Range(-1f, 1f);
            timer = 0f;
        }

        // 左右にふらふら + ランダム方向
        float x = Mathf.Sin(Time.time * moveSpeed) * moveRange * 0.1f;
        x += randomX * 0.05f;

        // 移動
        transform.Translate(new Vector3(x, -speed, 0) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

            ScoreManager.instance.AddScore(10);
        }
    }

    void OnBecameInvisible()
    {
        // 画面下に落ちた時だけミス扱いにする
        if (transform.position.y < -5f) // 画面下の位置に合わせて調整
        {
            GameManager.instance.Miss();
        }

        Destroy(gameObject);
    }


}
