using System;

namespace Fint.Relation.Model
{
    public class RelationBuilder
    {
        private readonly Relation _relation = new Relation(String.Empty, string.Empty);
        private string _type;
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

        public RelationBuilder ForType(string type)
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

            _relation.Link = _field == null
                ? $"${{{_type}}}/{_value}"
                : $"${{{_type}}}/{_field}/{_value}";

            return new Relation(_relation.RelationName, _relation.Link);
        }
    }
}