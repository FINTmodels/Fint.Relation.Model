using System;
namespace Fint.Relation.Model
{
    public class Relation
    {
        public string RelationName { get; set; }
        public string Link { get; set; }

        public Relation(string relationName, string link)
        {
            RelationName = relationName;
            Link = link;
        }

        public static RelationBuilder NewBuilder()
        {
            return new RelationBuilder();
        }
    }
}
