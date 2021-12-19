using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;
using System.IO;

public class LuaTest : MonoBehaviour
{
	private static LuaState ls_state;

	private void Start()
	{
		ls_state = new LuaState();

		//ls_state.doString("print(\"Hello Lua!\")");

		//加载Lua文件
		//ls_state.loaderDelegate = (string fn, ref string absoluteFn) =>
		//{
		//	string file_path = Directory.GetCurrentDirectory() + "/Assets/Scripts/Lua/" + fn;
		//	Debug.Log(file_path);
		//	return File.ReadAllBytes(file_path);
		//};

		//ls_state.doFile("HelloLua.lua");

		//string file_path = Directory.GetCurrentDirectory() + "/Assets/Script/Lua/";
		//Debug.Log(file_path);

		LuaSvr svr = new LuaSvr();
		LuaSvr.mainState.loaderDelegate += LuaResourcesFileLoader;
		svr.init(null, () =>
		{
			svr.start("Lua");
		});
	}

	//SLua Loader代理方法
	private static byte[] LuaResourcesFileLoader(string strFie, ref string absoluteFn)
	{
		string filename = Application.dataPath + "/Scripts/Lua/" + strFie.Replace('.', '/') + ".txt";
		return File.ReadAllBytes(filename);
	}
}
