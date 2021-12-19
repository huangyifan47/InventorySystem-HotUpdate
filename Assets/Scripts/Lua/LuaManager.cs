using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;
using System.IO;

public class LuaManager : MonoBehaviour
{
	private LuaFunction _luaStart = null;
	private LuaFunction _luaUpdate = null;
	private LuaFunction _luaLateUpdate = null;
	private LuaFunction _luaFixedUpdate = null;
	private LuaFunction _luaAwake = null;
	private LuaFunction _luaOnDisable = null;
	private LuaFunction _luaOnDestroy = null;

	private void Awake()
	{
		LuaSvr svr = new LuaSvr();
		LuaSvr.mainState.loaderDelegate += LuaResourcesFileLoader;
		//不用init方法初始化的话,在Lua中是不能import的
		svr.init(null, () =>
		{
			svr.start("Main");
			_luaAwake = LuaSvr.mainState.getFunction("Awake");
			_luaStart = LuaSvr.mainState.getFunction("Start");
			_luaFixedUpdate = LuaSvr.mainState.getFunction("FixedUpdate");
			_luaUpdate = LuaSvr.mainState.getFunction("Update");
			_luaLateUpdate = LuaSvr.mainState.getFunction("LateUpdate");
			_luaOnDisable = LuaSvr.mainState.getFunction("OnDisable");
			_luaOnDestroy = LuaSvr.mainState.getFunction("OnDestroy");

			if(_luaAwake != null)
			{
				_luaAwake.call();
			}
		});
	}

	private void Start()
	{
		if(_luaStart != null)
		{
			_luaStart.call();
		}
	}

	private void Update()
	{
		if (_luaUpdate != null)
		{
			_luaUpdate.call();
		}
	}

	private void LateUpdate()
	{
		if (_luaLateUpdate != null)
		{
			_luaLateUpdate.call();
		}
	}

	private void FixedUpdate()
	{
		if(_luaFixedUpdate != null)
		{
			_luaFixedUpdate.call();
		}
	}

	private void OnDisable()
	{
		if (_luaOnDisable != null)
		{
			_luaOnDisable.call();
		}
	}

	private void OnDestroy()
	{
		if (_luaOnDestroy != null)
		{
			_luaOnDestroy.call();
		}
	}


	//SLua Loader代理方法
	private static byte[] LuaResourcesFileLoader(string strFie, ref string absoluteFn)
	{
		string filename = Application.dataPath + "/Scripts/Lua/" + strFie.Replace('.', '/') + ".txt";
		return File.ReadAllBytes(filename);
	}
}
