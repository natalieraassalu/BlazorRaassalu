using System.Reflection;
using Abc.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Abc.Tests.Data;

public abstract class BaseTests<TClass> where TClass : class, new()
{
    private TClass obj;
    private const BindingFlags publicDeclared = BindingFlags.Public 
                                                | BindingFlags.DeclaredOnly
                                                | BindingFlags.Instance
                                                | BindingFlags.Static;

    [TestInitialize] public void Initialize() => obj = new TClass();

    [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);

    [TestMethod]
    public void IsCorrectClassTest()
    {
        var className = typeof(TClass).Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(className+"Tests",testClassName);
    }

    [TestMethod]
    public void IsClassTestedTest()
    {
        var testMethods = GetType().GetMethods().Select(x => x.Name);
        var membersToTest=getProperties().Concat(getMethods());
        foreach (var m in membersToTest)
        {
            if (testMethods.Contains(m + "Test"))
               Assert.Inconclusive($"{m} is not tested");
        }
    }

    private static IEnumerable<string> getProperties() => Aids.GetType.PropertyNames<TClass>(publicDeclared);

    private static IEnumerable<string> getMethods() 
        => Aids.GetType.MethodNames<TClass>(publicDeclared,false);

}