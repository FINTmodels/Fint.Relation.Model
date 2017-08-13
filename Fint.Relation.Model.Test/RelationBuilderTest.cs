using System;
using Xunit;

namespace Fint.Relation.Model.Test {
    public class RelationBuilderTest {
        [Fact]
        public void ThrowsExceptionOnEmptyRelationBuilder () {
            Assert.Throws<ArgumentException> (() => Relation.NewBuilder ().Build ());
        }

        [Fact]
        public void CreateRelationOnTypeAndValueInput () {
            Relation relation = Relation.NewBuilder ()
                .With (TestEnum.TEST1)
                .ForType (typeof (TestModel).Name.ToLower ())
                .Value ("testvalue")
                .Build ();
            Assert.Equal ("${testmodel}/testvalue", relation.Link);
            Assert.Equal (TestEnum.TEST1.ToString ().ToLower (), relation.RelationName);            
        }

        [Fact]
        public void CreateRelationOnTypeValueFieldInput () {
            Relation relation = Relation.NewBuilder ()
                .With (TestEnum.TEST1).ForType (typeof (TestModel).Name.ToLower ())
                .Value ("testvalue").Field ("systemid")
                .Build ();
            Assert.Equal ("${testmodel}/systemid/testvalue", relation.Link);
            Assert.Equal (TestEnum.TEST1.ToString ().ToLower (), relation.RelationName);            
        }

        [Fact]
        public void CreateRelationOnLinkInput () {
            Relation relation = Relation.NewBuilder ()
                .With (TestEnum.TEST1)
                .Link ("http://localhost/test")
                .Build ();

            Assert.Equal ("http://localhost/test", relation.Link);
            Assert.Equal (TestEnum.TEST1.ToString ().ToLower (), relation.RelationName);

        }
    }
}