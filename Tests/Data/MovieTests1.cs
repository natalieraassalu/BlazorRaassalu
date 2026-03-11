using Abc.Data;
namespace Abc.Tests.Data;

[TestClass] public sealed class MovieTests : BaseTests<Movie>
{
    [TestMethod] public void IdTest() => isProperty<Guid>(nameof(Movie.Id));

    private void isProperty<T>(string v)
    {
        throw new NotImplementedException();
    }

    [TestMethod] public void TitleTest() => Assert.Inconclusive();
    [TestMethod] public void ReleaseDsteTest() => Assert.Inconclusive();
    [TestMethod] public void GenreTest() => Assert.Inconclusive();
    [TestMethod] public void PriceTest() => isProperty<decimal>(nameof(Movie.Price));
}
