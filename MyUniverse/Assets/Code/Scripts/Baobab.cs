using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Baobab : MonoBehaviour
{
    [SerializeField] private Transform trunk;
    [SerializeField] private Transform tree;
    [SerializeField] private Transform brokenTree;
    [SerializeField] private Transform brokenTree2;
    [SerializeField] private float respawnTime = 3f;

    private int blowCount = 1;

    public void Blow()
    {
        {
            var sequence = DOTween.Sequence();

            sequence.Append(transform.DOScale(new Vector3(1, Random.Range(1.3f, 1.8f), 1), 0.1f));
            sequence.Append(transform.DOScale(0.8f, 0.1f));
            sequence.InsertCallback(0.2f, () =>
            {
                switch (blowCount)
                {
                    case 1:
                        tree.gameObject.SetActive(false);
                        brokenTree.gameObject.SetActive(true);
                        blowCount++;
                        StartCoroutine(nameof(RespawnTree));
                        break;
                    case 2:
                        brokenTree.gameObject.SetActive(false);
                        brokenTree2.gameObject.SetActive(true);
                        blowCount++;
                        break;
                    case 3:
                        brokenTree2.gameObject.SetActive(false);
                        trunk.gameObject.SetActive(true);
                        blowCount = 1;
                        break;
                }
            });
            sequence.OnComplete(() => { transform.DOScale(1f, 0.1f); });
        }
    }


    IEnumerator RespawnTree()
    {
        yield return new WaitForSeconds(respawnTime);
        tree.gameObject.SetActive(true);
        brokenTree.gameObject.SetActive(false);
        brokenTree2.gameObject.SetActive(false);
        trunk.gameObject.SetActive(false);

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(1.5f, 0.1f));
        sequence.OnComplete(() => { transform.DOScale(1f, 0.1f); });
    }
}