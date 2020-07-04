using System;
using System.Collections.Generic;
using System.Linq;

public class PersonRelationsFinder
{
    private List<Person> checkedPersons;
    private Dictionary<Person, List<Person>> personsRelations;
    private List<int> depths;

    private int minDepth = Int32.MaxValue;

    public PersonRelationsFinder()
    {
        checkedPersons = new List<Person>();
        personsRelations = new Dictionary<Person, List<Person>>();
        depths = new List<int>();
    }

    public void Init(Person[] people)
    {
        if (people.Length < 2)
            return;

        for (int i = 0; i < people.Length; i++)
        {
            if (personsRelations.ContainsKey(people[i]))
                continue;

            else
            {
                personsRelations.Add(people[i], new List<Person>());
                for (int j = 0; j < people.Length; j++)
                {
                    if (i != j)
                    {
                        if (people[i].Address.Equals(people[j].Address) || people[i].FullName.Equals(people[j].FullName))
                        {
                            personsRelations[people[i]].Add(people[j]);
                        }
                    }
                }
            }
        }
    }

    public int FindMinLevel(Person a, Person b){
        Find(a,b, 0);
        return depths.OrderBy(x => x).FirstOrDefault();
    }
    public void Find(Person personA, Person personB, int level)
    {
        if (personA == null || personB == null)
        {
            return;
        }

        //assumption: both persons must be in the persons list I get in Init function
        if (!personsRelations.ContainsKey(personA) || !personsRelations.ContainsKey(personB))
        {
            return;
        }

        List<Person> personsRelated = personsRelations[personA];
        if (personsRelated.Contains(personB))
        {
            depths.Add(level + 1);
            return;
        }


        foreach (var person in personsRelated)
        {
            if (personsRelations.ContainsKey(person) && personsRelations[person].Contains(personB))
            {
                depths.Add(level + 2);
                return;
            }
        }

        checkedPersons.Add(personA);
        foreach (var person in personsRelated)
        {
            if (!checkedPersons.Contains(person))
            {
                Find(person, personB, level + 1);
            }
        }
    }
}