using System;
using Xunit;

namespace Fint.Relation.Model.Test
{
    public class RelationBuilderTest
    {
        [Fact]
        public void ThrowsExceptionOnEmptyRelationBuilder()
        {
            Assert.Throws<ArgumentException>(() => new RelationBuilder().Build());
        }

        [Fact]
        public void CreateRelationOnTypeAndValueInput()
        {
            var relation = new RelationBuilder()
                .With(TestEnum.TEST1)
                .ForType(typeof(TestModel).Name.ToLower())
                .Value("testvalue")
                .Build();
            Assert.Equal("${testmodel}/testvalue", relation.Link);
            Assert.Equal(TestEnum.TEST1.ToString().ToLower(), relation.RelationName);
        }

        [Fact]
        public void CreateRelationOnTypeValueFieldInput()
        {
            var relation = new RelationBuilder()
                .With(TestEnum.TEST1).ForType(typeof(TestModel).Name.ToLower())
                .Value("testvalue")
                .Field("systemid")
                .Build();
            Assert.Equal("${testmodel}/systemid/testvalue", relation.Link);
            Assert.Equal(TestEnum.TEST1.ToString().ToLower(), relation.RelationName);
        }

        [Fact]
        public void CreateRelationOnLinkInput()
        {
            var relation = new RelationBuilder()
                .With(TestEnum.TEST1)
                .Link("http://localhost/test")
                .Build();

            Assert.Equal("http://localhost/test", relation.Link);
            Assert.Equal(TestEnum.TEST1.ToString().ToLower(), relation.RelationName);
        }
    }
}