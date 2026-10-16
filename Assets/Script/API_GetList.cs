using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class ToDos
{
    public int userId;
    public int id;
    public string title;
    public bool completed;
}

[System.Serializable]
public class TodosWrapper
{
    public List<ToDos> items;
}


public class API_GetList : MonoBehaviour
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
            Debug.Log(json);

            string wrappedJson = "{\"items\":" + json + "}";
            Debug.Log(wrappedJson);

            TodosWrapper wrapper = JsonUtility.FromJson<TodosWrapper>(wrappedJson);
            //Debug.Log(wrapper);
            ToDos todos = wrapper.items[0];

            //Debug.Log(todos);
            
            userId = todos.userId;
            Debug.Log(userId);

            //id = todos.id;
            //title = todos.title;
            //completed = todos.completed;


        }
        
    }
}
