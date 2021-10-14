# Net6Issue

The top level app must directly references to the assemblies used by it's referenced assemblies.

Here the app BlazorApp1 references to MyClass, and MyClass references to MyAbstractClass by assembly reference, not project reference.

When go to runtime, the exception logged in browser:

blazor.webassembly.js:1 crit: Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]
      Unhandled exception rendering component: Object reference not set to an instance of an object.
System.NullReferenceException: Object reference not set to an instance of an object.
   at Microsoft.AspNetCore.Components.Routing.Router.Refresh(Boolean isNavigationIntercepted)
   at Microsoft.AspNetCore.Components.Routing.Router.SetParametersAsync(ParameterView parameters)
window.Module.s.printErr @ blazor.webassembly.js:1
blazor.webassembly.js:1 crit: Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]
      Unhandled exception rendering component: Could not load type of field 'BlazorApp1.Pages.Counter:class1' (1) due to: Could not resolve type with token 0100000c from typeref (expected class 'MyAbstractClass.Disposable' in assembly 'MyAbstractClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null') assembly:MyAbstractClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null type:MyAbstractClass.Disposable member:(null)
System.TypeLoadException: Could not load type of field 'BlazorApp1.Pages.Counter:class1' (1) due to: Could not resolve type with token 0100000c from typeref (expected class 'MyAbstractClass.Disposable' in assembly 'MyAbstractClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null') assembly:MyAbstractClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null type:MyAbstractClass.Disposable member:(null)
   at System.RuntimeTypeHandle.CanCastTo(RuntimeType type, RuntimeType target)
   at System.RuntimeType.IsAssignableFrom(Type c)
   at Microsoft.AspNetCore.Components.RouteTableFactory.<GetRouteableComponents>g__GetRouteableComponents|4_0(List`1 routeableComponents, Assembly assembly)
   at Microsoft.AspNetCore.Components.RouteTableFactory.GetRouteableComponents(RouteKey routeKey)
   at Microsoft.AspNetCore.Components.RouteTableFactory.Create(RouteKey routeKey)
   at Microsoft.AspNetCore.Components.Routing.Router.RefreshRouteTable()
   at Microsoft.AspNetCore.Components.Routing.Router.Refresh(Boolean isNavigationIntercepted)
   at Microsoft.AspNetCore.Components.Routing.Router.RunOnNavigateAsync(String path, Boolean isNavigationIntercepted)
   at Microsoft.AspNetCore.Components.Routing.Router.<>c__DisplayClass62_0.<RunOnNavigateAsync>b__1(RenderTreeBuilder builder)
   at Microsoft.AspNetCore.Components.Rendering.ComponentState.RenderIntoBatch(RenderBatchBuilder batchBuilder, RenderFragment renderFragment, Exception& renderFragmentException)
   
   The workaround for this:
   1. References the MyAbstractClass from BlazorApp1. Or
   2. Use project reference from MyClass to MyAbstractClass.
   
   This is working fine in .Net 5.
   
