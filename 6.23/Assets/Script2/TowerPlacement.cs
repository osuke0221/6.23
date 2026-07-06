using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab1;
    public GameObject towerPrefab2;

    private GameObject selectedPrefab; // 選択中のタワー
    private GameObject previewTower;   // ドラッグ中のプレビュー

    void Update()
    {
        // タワーが選択されている状態で、ワールド上でドラッグ開始
        if (selectedPrefab != null && Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            // プレビュー生成
            previewTower = Instantiate(selectedPrefab);
            SetPreviewAlpha(previewTower, 0.5f);
        }

        // ドラッグ中ならプレビューを追従
        if (previewTower != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            previewTower.transform.position = pos;

            // 離したら設置
            if (Input.GetMouseButtonUp(0))
            {
                if (CanPlaceHere(pos))   // ★ 置ける場所かチェック
                {
                    Instantiate(selectedPrefab, pos, Quaternion.identity);
                }

                Destroy(previewTower);
                previewTower = null;
            }
        }
    }

    // 置けない場所判定（NoBuild の上なら false）
    bool CanPlaceHere(Vector3 pos)
    {
        Collider2D hit = Physics2D.OverlapPoint(pos);

        if (hit == null) return true; // 何もない場所は置ける

        if (hit.CompareTag("NoBuild"))
            return false;             // NoBuild の上は置けない

        return true;
    }

    public void SelectTower1()
    {
        selectedPrefab = towerPrefab1;
    }

    public void SelectTower2()
    {
        selectedPrefab = towerPrefab2;
    }

    void SetPreviewAlpha(GameObject obj, float alpha)
    {
        var sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            var c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }
}
