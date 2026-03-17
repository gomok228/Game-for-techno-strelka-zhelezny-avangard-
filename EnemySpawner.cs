using System.Collections;
using UnityEngine;
//типо скрипт спавнера врагов
public class EnemySpawner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject EnemyPrefab;
    private void Start()
    {
        StartCoroutine(SpawnCo());
    }
    void Repeat()
    {
        StartCoroutine(SpawnCo());
    }
   //корутина с респавном
    IEnumerator SpawnCo()
    {
        yield return new WaitForSeconds(20f);
        Instantiate(EnemyPrefab, SpawnPos.position,Quaternion.identity);
        Repeat();//функция - повторитель
    }
}
