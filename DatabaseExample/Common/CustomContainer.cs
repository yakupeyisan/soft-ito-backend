using System;
using Newtonsoft.Json;

namespace DatabaseExample.Common;

public static class CustomContainer
{
	private static List<dynamic> items = new();

	public static void AddContainer <IType, CType>()
		where IType : notnull
		where CType : IType, new()
    {
		items.Add(new CustomContainerItem<IType,CType>());
	}
	public static T? GetItem<T>()
	{
		items.ForEach(item =>
		{
			Console.WriteLine(item.Obj);
		});
		return items.Where(item=> item.Obj is T).Select(item=>(T)item.Obj).FirstOrDefault();
    }

    private class CustomContainerItem<IType, CType>
        where IType : notnull
        where CType : IType, new()
    {
        public IType Obj { get; set; } = new CType();
    }

}