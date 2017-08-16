using Xunit;

namespace Fint.Relation.Model.Test
{
    public class FintResourceTest
    {
        [Fact]
        public void CreateFintResource()
        {
            TestModel testModel = new TestModel();
            var relation = new RelationBuilder()
                .With(TestEnum.TEST1)
                .Link("http://localhost/test")
                .Build();

            FintResource<TestModel> fintResource = FintResource<TestModel>.With(testModel).AddRelasjoner(relation);

            Assert.Equal(testModel.GetType().Name.ToLower(), fintResource.Type);
            Assert.Equal(1, fintResource.Relasjoner.Count);
            Assert.Equal(relation, fintResource.Relasjoner[0]);
            Assert.Equal(testModel, fintResource.Resource);
        }
    }
}