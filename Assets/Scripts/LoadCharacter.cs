using Unity.VisualScripting;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public GameObject prefab;
    public GameObject clone;
    public GameObject clone2test;
    public GameObject cam;
    public Vector3 offset;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        prefab = characterPrefabs[selectedCharacter];
        clone = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        offset = new Vector3(0, 1.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        clone.transform.position = spawnPoint.transform.position;
        clone2test.transform.position = spawnPoint.transform.position;
        cam.transform.position = clone.transform.position + offset;
        cam.transform.rotation = clone.transform.rotation;
    }
}
