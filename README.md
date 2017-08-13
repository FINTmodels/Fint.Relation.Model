# FINT Relation Model
Fint relation model for `dotnet`

## Installation

* Add Bintray (nuget) repository ´https://api.bintray.com/nuget/fint/nuget´

## Usage

**Create a new Relation**  

With type, field and value
```csharp
Relation relation = Relation.NewBuilder ()
    .With (TestEnum.TEST1)
    .ForType (typeof (TestModel).Name.ToLower ())
    .Value ("testvalue")
    .Field ("systemid")
    .Build ();
```
or with type and value
```csharp
Relation relation = Relation.NewBuilder ()
    .With (TestEnum.TEST1)
    .ForType (typeof (TestModel).Name.ToLower ())
    .Value ("testvalue")
    .Build ();
```
or with link
```csharp
Relation relation = Relation.NewBuilder ()
    .With (TestEnum.TEST1)
    .Link ("http://localhost/test")
    .Build ();
```
----
**FintResource**
```csharp
FintResource<TestModel> fintResource = FintResource<TestModel>.With (testModel).AddRelations (relation);
```
