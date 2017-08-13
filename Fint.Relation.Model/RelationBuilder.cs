using System;
namespace Fint.Relation.Model
{
    public class RelationBuilder
    {
        string _relationName;
        string _link;
        string _type;
        string _field;
        string _value;


        public RelationBuilder With<T>(T relation) where T : IConvertible
        {
            _relationName = relation.ToString().ToLower();
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

        public RelationBuilder Link(string link)
        {
            _link = link;
            return this;
        }

        public Relation Build()
        {
            if (_link == null || _link.Equals(""))
            {
                if (_type == null || _value == null)
                {
                    throw new ArgumentException("Missing value to create Relation, either link value is set, or type, field and value");
                }

                if (_field == null)
                {
                    _link = string.Format("${{{0}}}/{1}", _type, _value);
                }
                else
                {
                    _link = string.Format("${{{0}}}/{1}/{2}", _type, _field, _value);
                }
                return new Relation(_relationName, _link);
            }
            return new Relation(_relationName, _link);
        }
    }
}
