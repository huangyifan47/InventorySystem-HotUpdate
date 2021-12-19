using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_UnityEngine_Rendering_RenderTargetBinding : LuaObject {
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
			int argc = LuaDLL.lua_gettop(l);
			UnityEngine.Rendering.RenderTargetBinding o;
			if(matchType(l,argc,2,typeof(UnityEngine.Rendering.RenderTargetIdentifier[]),typeof(UnityEngine.Rendering.RenderBufferLoadAction[]),typeof(UnityEngine.Rendering.RenderBufferStoreAction[]),typeof(UnityEngine.Rendering.RenderTargetIdentifier),typeof(UnityEngine.Rendering.RenderBufferLoadAction),typeof(UnityEngine.Rendering.RenderBufferStoreAction))){
				UnityEngine.Rendering.RenderTargetIdentifier[] a1;
				checkArray(l,2,out a1);
				UnityEngine.Rendering.RenderBufferLoadAction[] a2;
				checkArray(l,3,out a2);
				UnityEngine.Rendering.RenderBufferStoreAction[] a3;
				checkArray(l,4,out a3);
				UnityEngine.Rendering.RenderTargetIdentifier a4;
				checkValueType(l,5,out a4);
				UnityEngine.Rendering.RenderBufferLoadAction a5;
				a5 = (UnityEngine.Rendering.RenderBufferLoadAction)LuaDLL.luaL_checkinteger(l, 6);
				UnityEngine.Rendering.RenderBufferStoreAction a6;
				a6 = (UnityEngine.Rendering.RenderBufferStoreAction)LuaDLL.luaL_checkinteger(l, 7);
				o=new UnityEngine.Rendering.RenderTargetBinding(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(matchType(l,argc,2,typeof(UnityEngine.Rendering.RenderTargetIdentifier),typeof(UnityEngine.Rendering.RenderBufferLoadAction),typeof(UnityEngine.Rendering.RenderBufferStoreAction),typeof(UnityEngine.Rendering.RenderTargetIdentifier),typeof(UnityEngine.Rendering.RenderBufferLoadAction),typeof(UnityEngine.Rendering.RenderBufferStoreAction))){
				UnityEngine.Rendering.RenderTargetIdentifier a1;
				checkValueType(l,2,out a1);
				UnityEngine.Rendering.RenderBufferLoadAction a2;
				a2 = (UnityEngine.Rendering.RenderBufferLoadAction)LuaDLL.luaL_checkinteger(l, 3);
				UnityEngine.Rendering.RenderBufferStoreAction a3;
				a3 = (UnityEngine.Rendering.RenderBufferStoreAction)LuaDLL.luaL_checkinteger(l, 4);
				UnityEngine.Rendering.RenderTargetIdentifier a4;
				checkValueType(l,5,out a4);
				UnityEngine.Rendering.RenderBufferLoadAction a5;
				a5 = (UnityEngine.Rendering.RenderBufferLoadAction)LuaDLL.luaL_checkinteger(l, 6);
				UnityEngine.Rendering.RenderBufferStoreAction a6;
				a6 = (UnityEngine.Rendering.RenderBufferStoreAction)LuaDLL.luaL_checkinteger(l, 7);
				o=new UnityEngine.Rendering.RenderTargetBinding(a1,a2,a3,a4,a5,a6);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==2){
				UnityEngine.RenderTargetSetup a1;
				checkValueType(l,2,out a1);
				o=new UnityEngine.Rendering.RenderTargetBinding(a1);
				pushValue(l,true);
				pushValue(l,o);
				return 2;
			}
			else if(argc==0){
				o=new UnityEngine.Rendering.RenderTargetBinding();
				pushValue(l,true);
				pushObject(l,o);
				return 2;
			}
			return error(l,"New object failed.");
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
	static public int get_colorRenderTargets(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorRenderTargets);
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
	static public int set_colorRenderTargets(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.RenderTargetIdentifier[] v;
			checkArray(l,2,out v);
			self.colorRenderTargets=v;
			setBack(l,self);
			pushValue(l,true);
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
	static public int get_depthRenderTarget(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.depthRenderTarget);
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
	static public int set_depthRenderTarget(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.RenderTargetIdentifier v;
			checkValueType(l,2,out v);
			self.depthRenderTarget=v;
			setBack(l,self);
			pushValue(l,true);
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
	static public int get_colorLoadActions(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorLoadActions);
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
	static public int set_colorLoadActions(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.RenderBufferLoadAction[] v;
			checkArray(l,2,out v);
			self.colorLoadActions=v;
			setBack(l,self);
			pushValue(l,true);
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
	static public int get_colorStoreActions(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushValue(l,self.colorStoreActions);
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
	static public int set_colorStoreActions(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.RenderBufferStoreAction[] v;
			checkArray(l,2,out v);
			self.colorStoreActions=v;
			setBack(l,self);
			pushValue(l,true);
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
	static public int get_depthLoadAction(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.depthLoadAction);
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
	static public int set_depthLoadAction(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.RenderBufferLoadAction v;
			v = (UnityEngine.Rendering.RenderBufferLoadAction)LuaDLL.luaL_checkinteger(l, 2);
			self.depthLoadAction=v;
			setBack(l,self);
			pushValue(l,true);
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
	static public int get_depthStoreAction(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			pushValue(l,true);
			pushEnum(l,(int)self.depthStoreAction);
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
	static public int set_depthStoreAction(IntPtr l) {
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
			UnityEngine.Rendering.RenderTargetBinding self;
			checkValueType(l,1,out self);
			UnityEngine.Rendering.RenderBufferStoreAction v;
			v = (UnityEngine.Rendering.RenderBufferStoreAction)LuaDLL.luaL_checkinteger(l, 2);
			self.depthStoreAction=v;
			setBack(l,self);
			pushValue(l,true);
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
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.Rendering.RenderTargetBinding");
		addMember(l,"colorRenderTargets",get_colorRenderTargets,set_colorRenderTargets,true);
		addMember(l,"depthRenderTarget",get_depthRenderTarget,set_depthRenderTarget,true);
		addMember(l,"colorLoadActions",get_colorLoadActions,set_colorLoadActions,true);
		addMember(l,"colorStoreActions",get_colorStoreActions,set_colorStoreActions,true);
		addMember(l,"depthLoadAction",get_depthLoadAction,set_depthLoadAction,true);
		addMember(l,"depthStoreAction",get_depthStoreAction,set_depthStoreAction,true);
		createTypeMetatable(l,constructor, typeof(UnityEngine.Rendering.RenderTargetBinding),typeof(System.ValueType));
	}
}
