using System;
using System.Collections.Generic;

namespace Fint.Relation.Model {
    public class FintResource<T> {
        public T Resource { get; set; }
        public string Type { get; set; }
        public List<Relation> Relations { get; set; }

        public FintResource () {
            Relations = new List<Relation> ();
        }

        public FintResource (string type, T resource) {
            Type = type;
            Resource = resource;
            Relations = new List<Relation> ();
        }

        public FintResource<T> AddRelations (params Relation[] relations) {
            Relations.AddRange (relations);
            return this;
        }

        public FintResource<T> AddRelations (List<Relation> relations) {
            Relations.AddRange (relations);
            return this;
        }

        public static FintResource<T> With (T model) {
            return new FintResource<T> (model.GetType ().Name.ToLower (), model);
        }
    }
}