using System;
using System.Collections.Generic;
using System.Text;
using Abc.Aids;

namespace Abc.Tests.Aids;
[TestClass] public class TypeExtensionTests:TestAids
{
    [TestInitialize] public void Initialize() => type = typeof(TypeExtension);
    [TestMethod] public void IsBoolTest()
    {
        Assert.IsTrue(TypeExtension.IsBool(typeof(bool)));
        Assert.IsTrue(typeof(bool).IsBool());
        Assert.IsFalse(TypeExtension.IsBool(typeof(string)));
    }
    [TestMethod] public void IsBoolNullableTest()
    {
        Assert.IsTrue(TypeExtension.IsBool(typeof(bool)));
    }

    [DataRow(typeof(DateTime))]
    [DataRow(typeof(DateTime?))]
    [DataRow(typeof(DateOnly))]
    [DataRow(typeof(DateOnly?))]
    [TestMethod] public void IsDateTest(Type t)
    {
        Assert.IsTrue(TypeExtension.IsDate(t));
        Assert.IsTrue(t.IsDate());
    }

    [TestMethod] public void IsStringTest(Type t) 
    {
        Assert.IsTrue(TypeExtension.IsString(t));
        Assert.IsTrue(t.IsString());
    }

    [DataRow(typeof(sbyte))]
    [DataRow(typeof(sbyte?))]
    [DataRow(typeof(byte))]
    [DataRow(typeof(byte?))]
    [TestMethod] public void IsNumericTest(Type t)
    {
        Assert.IsTrue(TypeExtension.IsNumeric(t));
        Assert.IsTrue(t.IsNumeric());
    }
}