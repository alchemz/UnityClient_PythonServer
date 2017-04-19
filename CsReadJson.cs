using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class RootObject
{
    public string Name { get; set; }
    public int Level { get; set; }
    public List<int> Stats { get; set; }
}


public class RootObject_
{
    public string Name { get; set; }
    public int Level { get; set; }
    public List<List<int>> Stats { get; set; }
}


public class CsReadJson : MonoBehaviour {

    
    private string jsonString;
    private JsonData cmdData;


    private string jsonString_;
    private JsonData cmdData_;
    // Use this for initialization


	public Mesh mesh;
	public Material material;
	public int maxDepth;
	private int depth;

	private	int x_ ;
	private	int y_;
	private	int z_ ;

	private	int x_1 ;
	private	int y_1;
	private	int z_1 ;

	private	int x_2 ;
	private	int y_2;
	private	int z_2 ;


    void Start()
    {

        jsonString_ = File.ReadAllText(Application.dataPath + "/Resources/test2.json");
        RootObject_ stats_ = JsonMapper.ToObject<RootObject_>(jsonString_);
       
		x_ = stats_.Stats [0][0];
		y_ = stats_.Stats [0][1];
		z_ = stats_.Stats [0][2];

		x_1 = stats_.Stats [1][0];
		y_1 = stats_.Stats [1][1];
		z_1 = stats_.Stats [1][2];

		x_2 = stats_.Stats [2][0];
		y_2 = stats_.Stats [2][1];
		z_2 = stats_.Stats [2][2];
	
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		gameObject.AddComponent<MeshRenderer>().material = material;
		if (depth < maxDepth) {
			GameObject g1=	new GameObject ("g1");
			g1.transform.position = new Vector3 (x_, y_, z_);
			g1.AddComponent<MeshFilter>().mesh = mesh;
			g1.AddComponent<MeshRenderer>().material = material;

			GameObject g2=new GameObject ("g2");
			g2.transform.position = new Vector3 (x_1, y_1, z_1);
			g2.AddComponent<MeshFilter>().mesh = mesh;
			g2.AddComponent<MeshRenderer>().material = material;

			GameObject g3=new GameObject ("g3");
			g3.transform.position = new Vector3 (x_2, y_2, z_2);
			g3.AddComponent<MeshFilter>().mesh = mesh;
			g3.AddComponent<MeshRenderer>().material = material;

		}
		//transform.position = new Vector3 (x_, y_, z_);
      }
		
}


