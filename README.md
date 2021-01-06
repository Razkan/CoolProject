# What is CoolProject?

Started as something fun where I experimented with microservice architecture but decided to use it to add a full solution for one of my other hobbies.

It consist of three parts.

# 1. Frontend
Built with react and uses redux for global states.

# 2. Backend
One of the main concept I have been playing around with is being able to communicate through contracts (interfaces). The first thing I did was add three separate microservices, one frontend API, one backend API and one tracker. The backend API register endpoints at the tracker with what contract it returns. After the backend API has registred its endpoints, the frontend API can start ask the tracker if a specific contract exist. If it exists the tracker sends back a collection of URLs. The frontend API will then proceed with connecting to each endpoint and fetch the data. A contract can not be serialized nor deserialized with System.text.json, so I have added a custom converter that with the use of reflection will translate all the interfaces to a common structure during serialization:

```csharp
public interface IUser {
    string Name { get; set; }
    int Age { get; set; }
}
```

would be translate to:

```json
{
    "__type__": "<Implementation type that inherits IUser>",
    "name": "...",
    "age": 0 
}
```

And with the use of `__type__` deserialize it back to the specific implementation it previously had. With the current implementation the implementation and interface has to been shared between the microservices, but a future improvement would be to have this dynamically handled.

# 3. Database
Adapter written in C#, lots of reflection, and operates on a SQLIte database. I currently do recursive insert and select. Basically if the object is complex with nested objects, it will insert all those objects to their corresponding tables and add mapping between entity and interface through a lookup table (id:X can be found in table:Y). When select is done and the entity has a nested object, the table will have id references to the other tables, which is then looked up through the entity - interface table doing a recursive select on all the entities.