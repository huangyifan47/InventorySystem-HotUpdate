using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_PhysicsScene : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int constructor(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.PhysicsScene o;
			o=new UnityEngine.PhysicsScene();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsValid(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			var ret=self.IsValid();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int IsEmpty(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			var ret=self.IsEmpty();
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Simulate(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.PhysicsScene self;
			checkValueType(l,1,out self);
			System.Single a1;
			checkType(l,2,out a1);
			self.Simulate(a1);
			pushValue(l,true);
			setBack(l,self);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int Raycast(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			int argc = LuaDLL.lua_gettop(l);
			if(argc==6){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				System.Single a3;
				checkType(l,4,out a3);
				System.Int32 a4;
				checkType(l,5,out a4);
				UnityEngine.QueryTriggerInteraction a5;
				a5 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 6);
				var ret=self.Raycast(a1,a2,a3,a4,a5);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(LuaOut),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.RaycastHit a3;
				System.Single a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				UnityEngine.QueryTriggerInteraction a6;
				a6 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 7);
				var ret=self.Raycast(a1,a2,out a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				pushValue(l,a3);
				return 3;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Vector3),typeof(UnityEngine.Vector3),typeof(UnityEngine.RaycastHit[]),typeof(float),typeof(int),typeof(UnityEngine.QueryTriggerInteraction))){
				UnityEngine.PhysicsScene self;
				checkValueType(l,1,out self);
				UnityEngine.Vector3 a1;
				checkType(l,2,out a1);
				UnityEngine.Vector3 a2;
				checkType(l,3,out a2);
				UnityEngine.RaycastHit[] a3;
				checkArray(l,4,out a3);
				System.Single a4;
				checkType(l,5,out a4);
				System.Int32 a5;
				checkType(l,6,out a5);
				UnityEngine.QueryTriggerInteraction a6;
				a6 = (UnityEngine.QueryTriggerInteraction)LuaDLL.luaL_checkinteger(l, 7);
				var ret=self.Raycast(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,ret);
				return 2;
			}
			pushValue(l,false);
			LuaDLL.lua_pushstring(l,"No matched override function Raycast to call");
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int op_Equality(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.PhysicsScene a1;
			checkValueType(l,1,out a1);
			UnityEngine.PhysicsScene a2;
			checkValueType(l,2,out a2);
			var ret=(a1==a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int op_Inequality(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			Profiler.BeginSample(methodName);
			#endif
			#endif
			UnityEngine.PhysicsScene a1;
			checkValueType(l,1,out a1);
			UnityEngine.PhysicsScene a2;
			checkValueType(l,2,out a2);
			var ret=(a1!=a2);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			Profiler.EndSample();
			#endif
		}
		#endif
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.PhysicsScene");
		addMember(l,IsValid);
		addMember(l,IsEmpty);
		addMember(l,Simulate);
		addMember(l,Raycast);
		addMember(l,op_Equality);
		addMember(l,op_Inequality);
		createTypeMetatable(l,constructor, typeof(UnityEngine.PhysicsScene),typeof(System.ValueType));
	}
}
