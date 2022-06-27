using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;


public class GameManager : MonoBehaviour
{
    public List<string> gameData = new List<string>();

    public GameObject lotto;
    // Start is called before the first frame update
    void Start() {
        InitFile();

        for ( int i = 0; i < gameData.Count; i++){
        float x = Random.Range(-10,10);
        float y = Random.Range(-7,7);
        Instantiate(lotto, new Vector3(x, 20, y), Quaternion.Euler(0,0,0));
        }
        
        
        
    }

    void InitFile() {
        var path = Path.GetFullPath(".");

        using ( FileStream data = new FileStream(path+"/testFile.txt",FileMode.Open)){
            StreamReader reader = new StreamReader(data);
            StreamWriter writer = new StreamWriter(data);
        
            string readed = reader.ReadLine();
            Debug.Log(readed);

            foreach (string i in readed.Split(','))
            {
                gameData.Add(i);
            }
        }
        // writer.Write("1,2,3,4,5,6,7,8,9,10");
    }

    public void UpdateFile(int idx){
        if(!gameData.Contains(idx.ToString())){
            Debug.Log("없는 숫자를 Update 시도하였음.");
            return;
        }


        Debug.Log   (idx+"가 삭제되었습니다.");

        var path = Path.GetFullPath(".");
        using( FileStream data = new FileStream(path+"/testFile.txt", FileMode.Truncate)) {

            StreamWriter writer = new StreamWriter(data);
            
            string res = "";
            
            gameData.Remove(idx.ToString());
            for(int i = 0; i < gameData.Count; i++){
                res += gameData[i] + ",";
                // writer.Write("1,2,3,4,5,6,7,8,9,10");
            }

            if (res.Length > 1)
            {
                res = res.Substring(0, res.Length - 1);
            } else
            {
                res = "";
            }
            writer.Write(res);
            Debug.Log(res);
            writer.Flush();
            // reader.Close();
            writer.Close();
        }
        

         
        // foreach (string i in readed.Split(','))
        // {
        //     Debug.Log(i);
        // }
        // writer.Write("1,2,3,4,5,6,7,8,9,10");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
