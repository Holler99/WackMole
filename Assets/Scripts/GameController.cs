using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private void Awake ()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    [Header("SpawnPoint Variables")]
    public Transform spawnPoints;
    public List<Vector3> SpawnPointList = new List<Vector3>();

    [Header("Mole Variables")]
    public GameObject molePrefab;
    public List<GameObject> MolesInScene = new List<GameObject>();

    public Transform playerController;



    int score;

    private void Start()
    {
        StartFunction();
    }


    void StartFunction()
    {
        score = 0;
        foreach (Transform item in spawnPoints)
        {
            SpawnPointList.Add(item.localPosition);
        }

        InvokeRepeating("GetMole",1f,3f);
    }


    void GetMole()
    {

        if (SpawnPointList.Count > 0)
        {
            Vector3 randomPosition = SpawnPointList[Random.Range(0, SpawnPointList.Count)];
            SpawnPointList.Remove(randomPosition);

            GameObject currentMole = Instantiate(molePrefab,randomPosition,Quaternion.identity/*,transform*/);
            currentMole.transform.LookAt(new Vector3(playerController.position.x,currentMole.transform.position.y,playerController.position.z));
            currentMole.SetActive(true);
            MolesInScene.Add(currentMole);
        }
        else
        {
            Debug.Log("Reach Max Moles");
        }

    }

    public void DestroyMole(GameObject _mole)
    {
        SpawnPointList.Add(_mole.transform.localPosition);
        MolesInScene.Remove(_mole);
        Destroy(_mole);
        score++;
    }



}
