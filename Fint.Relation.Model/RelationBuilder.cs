using System;

namespace Fint.Relation.Model
{
    public class RelationBuilder
    {
        private readonly Relation _relation = new Relation(String.Empty, string.Empty);
        private Type _type;
        private string _value;
        private string _field;

        public RelationBuilder With<T>(T relation) where T : IConvertible
        {
            _relation.RelationName = relation.ToString().ToLower();
            return this;
        }

        public RelationBuilder Link(string link)
        {
            _relation.Link = link;
            return this;
        }

        public RelationBuilder ForType(Type type)
        {
            _type = type;
            return this;
        }

        public RelationBuilder Field(string field)
        {
            _field = field;
            return this;
        }

        public RelationBuilder Value(string value)
        {
            _value = value;
            return this;
        }

        public Relation Build()
        {
            if (!string.IsNullOrEmpty(_relation.Link))
            {
                return new Relation(_relation.RelationName, _relation.Link);
            }

            if (_type == null || _value == null)
            {
                throw new ArgumentException(
                    "Missing value to create Relation, either link value is set, or type, field and value");
            }

            var typeString = createType(_type);
            _relation.Link = _field == null
                ? $"${{{typeString}}}/{_value}"
                : $"${{{typeString}}}/{_field}/{_value}";

            return new Relation(_relation.RelationName, _relation.Link);
        }

        public static string createType(Type type)
        {
            return createType(type.FullName);
        }

        public static string createType(string type)
        {
            var fullName = type.ToLower();
            return fullName.Replace(@"fint.model.", "");
        }
    }
}