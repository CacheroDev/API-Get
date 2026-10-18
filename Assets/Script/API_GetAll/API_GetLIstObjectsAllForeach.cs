using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ToDos3
{
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[System.Serializable]
public class ToDos3Wrapper
{
    public List<ToDos3> items;
}

public class API_GetLIstObjectsAllForeach : MonoBehaviour
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

            ToDos3Wrapper wrapper = JsonUtility.FromJson<ToDos3Wrapper>(wrappedJson);

            if (wrapper.items != null && wrapper.items.Count > 0)
            {
                foreach (var myItems in wrapper.items)
                {
                    ToDos3 ToDos3 = myItems;

                    userId = ToDos3.userId;
                    id = ToDos3.id;
                    title = ToDos3.title;
                    completed = ToDos3.completed;

                    Debug.Log(userId);
                    Debug.Log(id);
                    Debug.Log(title);
                    Debug.Log(completed);
                }
            }
        }
    }
}
