using System;
using System.Collections.Generic;

namespace Fint.Relation.Model {
    public class FintResource<T> {
        public T Resource { get; set; }
        public string Type { get; set; }
        public List<Relation> Relasjoner { get; set; }

        public FintResource () {
            Relasjoner = new List<Relation> ();
        }

        public FintResource (string type, T resource) {
            Type = type;
            Resource = resource;
            Relasjoner = new List<Relation> ();
        }

        public FintResource<T> AddRelasjoner (params Relation[] relations) {
            Relasjoner.AddRange (relations);
            return this;
        }

        public FintResource<T> AddRelasjoner (List<Relation> relations) {
            Relasjoner.AddRange (relations);
            return this;
        }

        public static FintResource<T> With (T model) {
            return new FintResource<T> ("no.fint.pwfa.model." + model.GetType().Name, model);
        }
    }
}