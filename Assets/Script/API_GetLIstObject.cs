using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ToDos1
{
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[System.Serializable]
public class Todos1Wrapper
{
    public List<ToDos1> items;
}

public class API_GetLIstObject : MonoBehaviour
{
    [SerializeField] int userId;
    [SerializeField] int id;
    [SerializeField] string title;
    [SerializeField] bool completed;

    void Start()
    {
        StartCoroutine(GetData());
    }

    IEnumerator GetData()
    {
        string url = "https://jsonplaceholder.typicode.com/todos";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }

            string json = request.downloadHandler.text;
            string wrappedJson = "{\"items\":" + json + "}";

            Todos1Wrapper wrapper = JsonUtility.FromJson<Todos1Wrapper>(wrappedJson);
            ToDos1 todos1 = wrapper.items[0];

            userId = todos1.userId;
            id = todos1.id;
            title = todos1.title;
            completed = todos1.completed;

            Debug.Log(userId);
            Debug.Log(id);
            Debug.Log(title);
            Debug.Log(completed);
        }
    }
}
