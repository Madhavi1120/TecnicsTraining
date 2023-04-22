using System;
using Method;
using Test;

class UsingInterface
{
	public static void Main(String[] args)
	{
		var className = args[0];
		//InvokeMethod(className, "PrintHello");
		iMethod o = new iMethod();
		o.PrintHello();
		ITest o1 = new iMethod();
		o1.PrintHello();

		//---------------------------------------------------------------

		//className.PrintHello();
		/*System.Activator.CreateInstance(Type.GetType(className));
		className.PrintHello();*/

		/*var instance = Activator.CreateInstance("iMethod",className);
		instance.PrintHello();
*/

		/*Type hai = Type.GetType(classString,true);
		Object o = (Activator.CreateInstance(hai)); */
		//ClassGet(className);

	}

	private void InvokeMethod(string className, string methodName)
	{
	    Assembly currentAssembly = Assembly.GetExecutingAssembly();
	    Type myType = currentAssembly.GetType(className);
	    MethodInfo myMethod = myType.GetMethod(methodName);
	    object instance = Activator.CreateInstance(myType);
	    myMethod.Invoke(instance, null);
	}

	/*public static void ClassGet(class MyClassName, string ClassName)
	{
    	MyClassName NewInstance = new MyClassName();
    	NewInstance.PrintHello();
	}*/

	/*public void ClassGet<MyClassName>(string blabla) where MyClassName : new() 
	{
  		MyClassName NewInstance = new MyClassName();
	}*/
}